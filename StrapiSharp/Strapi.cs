using System.Text;
using System.Net.Http.Headers;
using StrapiSharp.Requests;
using StrapiSharp.Enums;

namespace StrapiSharp;

/// <summary>
/// Exception used when a request receives an error from the host.
/// </summary>
public class StrapiRequestException: Exception
{
	/// <summary>
	/// A JSON <see cref="string"/> returned from Strapi containing the error.
	/// </summary>
	public string Response { get; set; }

	/// <summary>
	/// Thrown when host responds with an error.
	/// </summary>
	/// <param name="message">Message to be thrown with the exception.</param>
	/// <param name="response">The JSON <see cref="string"/> returned from the server containing the error.</param>
	public StrapiRequestException(string message, string response) : base(message)
	{
		Response = response;
	}
}

public class Strapi
{
	private readonly HttpClient _httpClient;

	/// <summary>
	/// The Strapi host to make requests against.
	/// </summary>
	public string Host { get; private set; }

	/// <summary>
	/// An authentication token that will be sent with each request, if set.
	/// </summary>
	public string AuthToken { get; set; } = string.Empty;

	/// <summary>
	/// Creates a new instance of <see cref="Strapi"/>.
	/// </summary>
	/// <param name="client">The <see cref="HttpClient"/> that will be used for requests.</param>
	/// <param name="host">The Strapi server base url where requests will be sent.</param>
	public Strapi(HttpClient client, string host)
	{
		_httpClient = client;
		SetDefaultRequestHeaders();
		Host = host;
	}

	/// <summary>
	/// Creates a new instance of <see cref="Strapi"/>.
	/// Creates a new <see cref="HttpClient"/> to be used.
	/// </summary>
	/// <param name="host">The Strapi server base url where requests will be sent.</param>
	public Strapi(string host)
	{
		_httpClient = new HttpClient();
		SetDefaultRequestHeaders();
		Host = host;
	}

	/// <summary>
	/// Sets the request headers for <see cref="_httpClient"/> to accept and receive JSON.
	/// </summary>
	private void SetDefaultRequestHeaders()
	{
		_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		_httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf8");
	}

	/// <summary>
	/// Sends an async <see cref="RequestBase"/> derived request to the <see cref="Host"/>.
	/// <example>
	/// For example:
	/// <code>
	/// var response = await ExecuteAsync(new FetchRequest("users", 1));
	/// </code>
	/// </example>
	/// </summary>
	/// <param name="request">Any request type inheriting from <see cref="RequestBase"/>.</param>
	/// <returns>A JSON <see cref="string"/> from the host of the <see cref="RequestBase"/> content type.</returns>
	/// <exception cref="StrapiRequestException">Thrown if the host returns an error.</exception>
	public async Task<string> ExecuteAsync(RequestBase request)
	{
		var message = new HttpRequestMessage(new HttpMethod(request.Method.ToString()), BuildURI(request));
		if (string.IsNullOrEmpty(request.Body) == false)
		{
			message.Content = new StringContent(request.Body, Encoding.UTF8, "application/json");
		}

		if (string.IsNullOrEmpty(AuthToken) == false)
		{
			message.Headers.Authorization = new AuthenticationHeaderValue("bearer", AuthToken);
		}

		var response = await _httpClient.SendAsync(message);
		if (response.IsSuccessStatusCode)
		{
			return await response.Content.ReadAsStringAsync();
		}
		else
		{
			var error = await response.Content.ReadAsStringAsync();
			throw new StrapiRequestException($"Failed to get success response from host! Host returned an error.", error);
		}
	}

	/// <summary>
	/// Builds a URI string for a <see cref="RequestBase"/> inherited request from its properties.
	/// </summary>
	/// <param name="request">The <see cref="RequestBase"/> whos properties will be pulled</param>
	/// <returns>A fully formed URI <see cref="string"/> for the request.</returns>
	public string BuildURI(RequestBase request)
	{
		var uri = Host;
		uri += (uri.EndsWith("/") == false) ? "/" : string.Empty;
		uri += request.ContentType;
		uri += (string.IsNullOrEmpty(request.Path) == false) ? $"{request.Path}" : string.Empty;
		if(request.Filters.Count > 0)
		{
			int inIndex = 0;
			int notInIndex = 0;
			int populateIndex = 0;

			uri += "?";
			foreach(var filter in request.Filters)
			{
				switch(filter.Type)
				{
					case "populate":
						uri += $"populate[{populateIndex.ToString()}]={filter.Field}";
						populateIndex++;
						break;

					case "sort":
						uri += $"sort[0]={filter.Field}:{filter.Value}";
						break;

					case "randomSort":
						uri += $"randomSort={filter.Value}";
						break;

					case "pagination":
						uri += $"pagination[{filter.Field}]={filter.Value}";
						break;

					case "$in":
						uri += $"filters[{filter.Field}][{filter.Type}][{inIndex.ToString()}]={filter.Value}";
						inIndex++;
						break;

					case "$notIn":
						uri += $"filters[{filter.Field}][{filter.Type}][{notInIndex.ToString()}]={filter.Value}";
						notInIndex++;
						break;

					case "$notNull":
					case "$null":
						uri += $"filters[{filter.Field}][{filter.Type}]";
						break;

					default:
						uri += $"filters[{filter.Field}][{filter.Type}]={filter.Value}";
						break;
				}
				uri += "&";
			}
		}
		uri = (uri.EndsWith("&") == true) ? uri.Remove(uri.Count() - 1) : uri;

		return uri;
	}
}
