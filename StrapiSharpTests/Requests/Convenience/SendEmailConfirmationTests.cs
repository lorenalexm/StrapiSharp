namespace StrapiSharpTests.Requests.Convenience;

public class SendEmailConfirmationTests
{
	/// <summary>
	/// Tests creating a new <see cref="SendEmailConfirmationRequest"/> and that properties match.
	/// </summary>
	[Test]
	public void SendEmailConfirmationRequest()
	{
		var request = new SendEmailConfirmationRequest("test@email.test");
		request.Method.Should().Be(RequestMethod.Post);
		request.ContentType.Should().Be("auth");
		request.Path.Should().Be("/send-email-confirmation");
		request.Body.Should().Be("{ \"email\": \"test@email.test\" }");
	}
}

