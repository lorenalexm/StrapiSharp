namespace StrapiSharpTests.Requests;

public class CreateRequestTests
{
	/// <summary>
	/// Tests creating a new <see cref="CreateRequest"/> and that properties match.
	/// </summary>
	[Test]
	public void CreateRequest()
	{
		var body = """{ "data": "request body data" }""";
		var request = new CreateRequest("testing", body);
		request.Method.Should().Be(RequestMethod.Post);
		request.ContentType.Should().Be("testing");
		request.Body.Should().Be(body);
	}
}

