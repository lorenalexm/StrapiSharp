namespace StrapiSharpTests.Requests.Convenience;

public class MeRequestTests
{
	/// <summary>
	/// Tests creating a new <see cref="MeRequest"/> and that properties match.
	/// </summary>
	[Test]
	public void MeRequest()
	{
		var request = new MeRequest();
		request.Method.Should().Be(RequestMethod.Get);
		request.ContentType.Should().Be("users");
		request.Path.Should().Be("/me");
	}
}

