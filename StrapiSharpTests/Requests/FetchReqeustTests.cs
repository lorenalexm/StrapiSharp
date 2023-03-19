namespace StrapiSharpTests.Requests;

public class FetchRequestTests
{
	/// <summary>
	/// Tests creating a new <see cref="FetchRequest"/> and that properties match.
	/// </summary>
	[Test]
	public void FetchRequest()
	{
		var request = new FetchRequest("testing", 32);
		request.Method.Should().Be(RequestMethod.Get);
		request.ContentType.Should().Be("testing");
		request.Path.Should().Be("/32");
	}
}
