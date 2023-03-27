using StrapiSharp.Enums;
using StrapiSharp.Models;
using StrapiSharp.Requests;

namespace StrapiSharp.Requests.Convenience;

/// <summary>
/// Convenience request type used for retrieving the logged in user.
/// <c>GET /users/me</c>
/// </summary>
public class MeRequest : RequestBase
{
	/// <summary>
	/// Creates the <see cref="MeRequest"/>.
	/// </summary>
	public MeRequest()
		: base(RequestMethod.Get, "users", "/me")
	{
	}
}

