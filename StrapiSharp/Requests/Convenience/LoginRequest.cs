using StrapiSharp.Enums;
using StrapiSharp.Models;
using StrapiSharp.Requests;

namespace StrapiSharp.Requests.Convenience;

/// <summary>
/// Convenience request type used for loging in users.
/// <c>POST /auth/local</c>
/// </summary>
public class LoginRequest : RequestBase
{
	/// <summary>
	/// Creates the <see cref="LoginRequest"/> and sets the body.
	/// </summary>
	/// <param name="identifier">The identifier used for a user object.</param>
	/// <param name="password">The password for the user.</param>
	public LoginRequest(string identifier, string password)
		: base(RequestMethod.Post, "auth", "/local", null)
	{
		SetBody($"{{ \"identifier\": \"{identifier}\", \"password\": \"{password}\" }}");
	}
}

