using StrapiSharp.Enums;

namespace StrapiSharp.Requests;

/// <summary>
/// Request type used for all Update requests against the Strapi server.
/// <c>PUT /{contentType}/{id}</c>
/// </summary>
public class UpdateRequest : RequestBase
{
	/// <summary>
	/// Creates the <see cref="RequestMethod.Put"/> request and sets the path and body.
	/// </summary>
	/// <param name="contentType">The Strapi type of this request.</param>
	/// <param name="id">The Strapi ID of the record to update.</param>
	/// <param name="body">The JSON body string.</param>
	public UpdateRequest(string contentType, int id, string body)
		: base(RequestMethod.Put, contentType, $"/{id}")
	{
		SetBody(body);
	}
}
