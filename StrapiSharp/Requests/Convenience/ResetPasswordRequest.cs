using StrapiSharp.Enums;
using StrapiSharp.Models;
using StrapiSharp.Requests;

namespace StrapiSharp.Requests.Convenience;

/// <summary>
/// Convenience request type used for finishing forgotten password flow.
/// <c>POST /auth/reset-password</c>
/// </summary>
public class ResetPasswordRequest : RequestBase
{
	/// <summary>
	/// Attempts to finish the forgotten password flow with Strapi local authentication.
	/// </summary>
	/// <param name="code">The security code received from Strapi.</param>
	/// <param name="password">The new password for the user.</param>
	/// <param name="passwordConfirmation">The confirmed password for the user.</param>
	public ResetPasswordRequest(string code, string password, string passwordConfirmation)
		: base(RequestMethod.Post, "auth", "/reset-password")
	{
		SetBody($"{{ \"code\": \"{code}\", \"password\": \"{password}\", \"passwordConfirmation\": \"{passwordConfirmation}\" }}");
	}
}

