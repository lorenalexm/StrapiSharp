using StrapiSharp.Enums;

namespace StrapiSharp.Requests;

/// <summary>
/// Request type used for all Fetch requests against the Strapi server.
/// <c>GET /{contentType}/{id}</c>
/// </summary>
public class FetchRequest : RequestBase
{
	/// <summary>
	/// Creates the <see cref="RequestMethod.Get"/> request.
	/// </summary>
	/// <param name="contentType">The Strapi type of this request.</param>
	/// <param name="id">The Strapi ID of the record to fetch.</param>
	public FetchRequest(string contentType, int id)
		: base(RequestMethod.Get, contentType, $"/{id}")
	{
	}
}
