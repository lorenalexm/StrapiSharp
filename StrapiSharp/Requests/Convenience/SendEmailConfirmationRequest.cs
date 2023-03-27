using StrapiSharp.Enums;
using StrapiSharp.Models;
using StrapiSharp.Requests;

namespace StrapiSharp.Requests.Convenience;

/// <summary>
/// Convenience request type used for resending email confirmation.
/// <c>POST /auth/send-email-confirmation</c>
/// </summary>
public class SendEmailConfirmationRequest : RequestBase
{
	/// <summary>
	/// Attempts to restart email confirmation flow with Strapi local authentication.
	/// </summary>
	/// <param name="email">Email associated with the user account.</param>
	public SendEmailConfirmationRequest(string email)
		: base(RequestMethod.Post, "auth", "/send-email-confirmation")
	{
		SetBody($"{{ \"email\": \"{email}\" }}");
	}
}

