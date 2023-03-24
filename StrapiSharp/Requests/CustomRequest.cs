using StrapiSharp.Enums;
using StrapiSharp.Models;

namespace StrapiSharp.Requests
{
	/// <summary>
	/// Request type used for all custom/user-defined requests against the Strapi server.
	/// <c>GET/POST/PUT/DELETE /{contentType}</c>
	/// </summary>
	public class CustomRequest : RequestBase
	{
		/// <summary>
		/// Creates the request.
		/// </summary>
		/// <param name="method">Which <see cref="RequestMethod"/> should this request use?</param>
		/// <param name="contentType">The Strapi type of this request.</param>
		/// <param name="path">A custom path to send this request to.</param>
		public CustomRequest(RequestMethod method, string contentType, string path = "")
			: base(method, contentType, path, null)
		{
		}
	}
}

