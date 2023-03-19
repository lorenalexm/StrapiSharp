namespace StrapiSharpTests.Requests;

public class UpdateRequestTests
{
	/// <summary>
	/// Tests creating a new <see cref="UpdateRequest"/> and that properties match.
	/// </summary>
	[Test]
	public void UpdateRequest()
	{
		var body = """{ "data": "request body data" }""";
		var request = new UpdateRequest("testing", 32, body);
		request.Method.Should().Be(RequestMethod.Put);
		request.ContentType.Should().Be("testing");
		request.Path.Should().Be("/32");
		request.Body.Should().Be(body);
	}
}
