namespace StrapiSharpTests.Requests.Convenience;

public class RegisterRequestTests
{
	/// <summary>
	/// Tests creating a new <see cref="RegisterRequest"/> and that properties match.
	/// </summary>
	[Test]
	public void RegisterRequest()
	{
		var request = new RegisterRequest("username", "test@email.test", "password");
		request.Method.Should().Be(RequestMethod.Post);
		request.ContentType.Should().Be("auth");
		request.Path.Should().Be("/local/register");
		request.Body.Should().Be("{ \"username\": \"username\", \"email\": \"test@email.test\", \"password\": \"password\" }");
	}
}
