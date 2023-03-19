using StrapiSharp.Enums;
using StrapiSharp.Models;

namespace StrapiSharp.Requests;

/// <summary>
/// Request type used for all Query requests against the Strapi server.
/// <c>GET /{contentType}</c>
/// </summary>
public class QueryRequest : RequestBase
{
	/// <summary>
	/// Creates the <see cref="RequestMethod.Get"/> request.
	/// </summary>
	/// <param name="contentType">The Strapi type of this request.</param>
	public QueryRequest(string contentType)
		: base(RequestMethod.Get, contentType)
	{
	}

	/// <summary>
	/// Creates the <see cref="RequestMethod.Get"/> request.
	/// </summary>
	/// <param name="contentType">The Strapi type of this request.</param>
	/// <param name="filters">Any preconstructed filters for the request.</param>
	public QueryRequest(string contentType, List<RequestFilter> filters)
		: base(RequestMethod.Get, contentType, "", filters)
	{
	}
}
