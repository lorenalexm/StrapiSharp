using StrapiSharp.Enums;

namespace StrapiSharp.Requests;

/// <summary>
/// Request type used for all Update requests against the Strapi server.
/// <c>DELETE /{contentType}/{id}</c>
/// </summary>
public class DestroyRequest : RequestBase
{
	/// <summary>
	/// Creates the <see cref="RequestMethod.Delete"/> request.
	/// </summary>
	/// <param name="contentType">The Strapi type of this request.</param>
	/// <param name="id">The Strapi ID of the record to delete.</param>
	public DestroyRequest(string contentType, int id)
		: base(RequestMethod.Delete, contentType, $"/{id}")
	{
	}
}
