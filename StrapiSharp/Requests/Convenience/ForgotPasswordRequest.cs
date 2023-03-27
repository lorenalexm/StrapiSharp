using StrapiSharp.Enums;
using StrapiSharp.Models;
using StrapiSharp.Requests;

namespace StrapiSharpTests.Requests.Convenience;

/// <summary>
/// Convenience request type used for starting forgotten password flow.
/// <c>POST /auth/forgot-password</c>
/// </summary>
public class ForgotPasswordRequest : RequestBase
{
	/// <summary>
	/// Attempts to initiate the forgotten password flow with Strapi local authentication.
	/// </summary>
	/// <param name="email">Email associated with the user account.</param>
	public ForgotPasswordRequest(string email)
		: base(RequestMethod.Post, "auth", "/forgot-password", null)
	{
		SetBody($"{{ \"email\": \"{email}\" }}");
	}
}