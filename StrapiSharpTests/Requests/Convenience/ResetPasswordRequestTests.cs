namespace StrapiSharpTests.Requests.Convenience;

public class ResetPasswordRequestTests
{
	/// <summary>
	/// Tests creating a new <see cref="ResetPasswordRequest"/> and that properties match.
	/// </summary>
	[Test]
	public void ResetPasswordRequest()
	{
		var request = new ResetPasswordRequest("ABC123", "password", "password");
		request.Method.Should().Be(RequestMethod.Post);
		request.ContentType.Should().Be("auth");
		request.Body.Should().Be("{ \"code\": \"ABC123\", \"password\": \"password\", \"passwordConfirmation\": \"password\" }");
	}
}

