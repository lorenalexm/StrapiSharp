namespace StrapiSharpTests.Requests;

public class DestroyRequestTests
{
	/// <summary>
	/// Tests creating a new <see cref="DestroyRequest"/> and that properties match.
	/// </summary>
	[Test]
	public void DestroyRequest()
	{
		var request = new DestroyRequest("testing", 32);
		request.Method.Should().Be(RequestMethod.Delete);
		request.ContentType.Should().Be("testing");
		request.Path.Should().Be("/32");
	}
}
