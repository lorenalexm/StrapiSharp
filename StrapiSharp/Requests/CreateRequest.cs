using StrapiSharp.Enums;

namespace StrapiSharp.Requests;

/// <summary>
/// Request type used for all Create requests against the Strapi server.
/// <c>POST /{contentType}</c>
/// </summary>
public class CreateRequest : RequestBase
{
	/// <summary>
	/// Creates the <see cref="RequestMethod.Post"/> request and sets the body.
	/// </summary>
	/// <param name="contentType">The Strapi type of this request.</param>
	/// <param name="body">The JSON body string.</param>
	public CreateRequest(string contentType, string body)
		: base(RequestMethod.Post, $"{contentType}")
	{
		SetBody(body);
	}
}
