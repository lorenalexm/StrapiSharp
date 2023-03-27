using StrapiSharp.Enums;
using StrapiSharp.Models;
using StrapiSharp.Requests;

namespace StrapiSharp.Requests.Convenience;

/// <summary>
/// Convenience request type used for loging in users.
/// <c>POST /auth/local/register</c>
/// </summary>
public class RegisterRequest : RequestBase
{
	/// <summary>
	/// Creates the <see cref="RegisterRequest"/> and sets the body.
	/// </summary>
	/// <param name="username">The requested username for the user.</param>
	/// <param name="email">The email to be associated with this user.</param>
	/// <param name="password">The password for the account to be created</param>
	public RegisterRequest(string username, string email, string password)
		: base(RequestMethod.Post, "auth", "/local/register", null)
	{
		SetBody($"{{ \"username\": \"{username}\", \"email\": \"{email}\", \"password\": \"{password}\" }}");
	}
}

