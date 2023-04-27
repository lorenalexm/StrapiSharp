namespace StrapiSharp.Requests.Convenience;

class ForgotPasswordRequestTests
{
	/// <summary>
	/// Tests creating a new <see cref="ForgotPasswordRequest"/> and that properties match.
	/// </summary>
	[Test]
	public void ForgotPasswordRequest()
	{
		var request = new ForgotPasswordRequest("test@email.test");
		request.Method.Should().Be(RequestMethod.Post);
		request.ContentType.Should().Be("auth");
		request.Path.Should().Be("/forgot-password");
		request.Body.Should().Be("{ \"email\": \"test@email.test\" }");
	}
}
