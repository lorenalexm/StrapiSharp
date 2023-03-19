namespace StrapiSharpTests.Requests;

public class QueryRequestTests
{
	/// <summary>
	/// Tests creating a new <see cref="QueryRequest"/>.
	/// </summary>
	[Test]
	public void QueryRequest()
	{
		var request = new QueryRequest("testing");
		request.Method.Should().Be(RequestMethod.Get);
		request.ContentType.Should().Be("testing");
	}

	/// <summary>
	/// Tests creating a new <see cref="QueryRequest"/> with a precreated <see cref="RequestFilter"/>.
	/// </summary>
	public void QueryRequestWithFilters()
	{
		var filters = new List<RequestFilter>();
		filters.Add(new RequestFilter { Type = "$notNull", Field = "test", Value = "testing" });

		var request = new QueryRequest("testing", filters);
		request.Method.Should().Be(RequestMethod.Get);
		request.ContentType.Should().Be("testing");
		request.Filters.Count.Should().Be(1);
		request.Filters[0].Type.Should().Be("$notNull");
	}
}
