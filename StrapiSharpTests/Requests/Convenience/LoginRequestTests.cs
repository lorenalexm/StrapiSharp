namespace StrapiSharpTests.Requests.Convenience;

public class LoginRequestTests
{
	/// <summary>
	/// Tests creating a new <see cref="LoginRequest"/> and that properties match.
	/// </summary>
	[Test]
	public void LoginRequest()
	{
		var request = new LoginRequest("username", "password");
		request.Method.Should().Be(RequestMethod.Post);
		request.ContentType.Should().Be("auth");
		request.Path.Should().Be("/local");
		request.Body.Should().Be("{ \"identifier\": \"username\", \"password\": \"password\" }");
	}
}

