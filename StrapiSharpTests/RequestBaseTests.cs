namespace StrapiSharpTests;

public class RequestBaseTests
{
	/// <summary>
	/// Mock request class as <see cref="RequestBase"/> is abstract.
	/// </summary>
	public class RequestBaseMock : RequestBase
	{
		public RequestBaseMock(RequestMethod method, string contentType, string path, List<RequestFilter>? filters = null)
			: base(method, contentType, path, filters)
		{
		}
	}

	/// <summary>
	/// Tests creating a basic request with no parameters.
	/// </summary>
	[Test]
	public void RequestBaseWithNoFilters()
	{
		var request = new RequestBaseMock(RequestMethod.Get, "test", "");
		request.Method.Should().Be(RequestMethod.Get);
		request.ContentType.Should().Be("test");
		request.Path.Should().Be("");
		request.Filters.Count.Should().Be(0);
	}

	/// <summary>
	/// Tests adding a single filter to a request.
	/// </summary>
	[Test]
	public void RequestBaseWithFilter()
	{
		var request = new RequestBaseMock(RequestMethod.Get, "test", "");
		request.Method.Should().Be(RequestMethod.Get);
		request.ContentType.Should().Be("test");
		request.Path.Should().Be("");

		request.Filter(FilterType.EqualTo, "test", "testing");
		request.Filters.Count.Should().Be(1);
		request.Filters[0].Type.Should().Be("$eq");
		request.Filters[0].Field.Should().Be("test");
		request.Filters[0].Value.Should().Be("testing");
	}

	/// <summary>
	/// Tests adding multiple filters to a request.
	/// </summary>
	[Test]
	public void RequestBaseWithFilters()
	{
		var request = new RequestBaseMock(RequestMethod.Get, "test", "");
		request.Method.Should().Be(RequestMethod.Get);
		request.ContentType.Should().Be("test");
		request.Path.Should().Be("");

		request.Filter(FilterType.EqualTo, "test", "testing");
		request.Filters.Count.Should().Be(1);
		request.Filters[0].Type.Should().Be("$eq");
		request.Filters[0].Field.Should().Be("test");
		request.Filters[0].Value.Should().Be("testing");

		request.Filter(FilterType.NotIn, "array", "others");
		request.Filters.Count.Should().Be(2);
		request.Filters[1].Type.Should().Be("$notIn");
		request.Filters[1].Field.Should().Be("array");
		request.Filters[1].Value.Should().Be("others");

		request.Filter(FilterType.LessThan, "number", "4");
		request.Filters.Count.Should().Be(3);
		request.Filters[2].Type.Should().Be("$lt");
		request.Filters[2].Field.Should().Be("number");
		request.Filters[2].Value.Should().Be("4");
	}

	/// <summary>
	/// Tests that filters cannot be applied to a <see cref="RequestMethod"/> that is not <see cref="RequestMethod.Get"/>.
	/// </summary>
	[Test]
	public void RequestBaseWithInvalidFilter()
	{
		var request = new RequestBaseMock(RequestMethod.Post, "test", "");
		request.Method.Should().Be(RequestMethod.Post);
		request.ContentType.Should().Be("test");
		request.Path.Should().Be("");

		request.Filter(FilterType.EqualTo, "test", "testing");
		request.Filters.Count.Should().Be(0);
	}

	/// <summary>
	/// Tests that a request body can be set with a <see cref="RequestMethod.Post"/> request.
	/// </summary>
	[Test]
	public void RequestBaseWithPostBody()
	{
		var body = """
			{ "data": "A random string or something." }
		""";

		var request = new RequestBaseMock(RequestMethod.Post, "test", "");
		request.Method.Should().Be(RequestMethod.Post);
		request.ContentType.Should().Be("test");
		request.Path.Should().Be("");

		request.SetBody(body);
		request.Body.Should().Be(body);

		request = new RequestBaseMock(RequestMethod.Put, "test", "");
		request.Method.Should().Be(RequestMethod.Put);
		request.ContentType.Should().Be("test");
		request.Path.Should().Be("");

		request.SetBody(body);
		request.Body.Should().Be(body);
	}

	/// <summary>
	/// Tests that a request body can be set with a <see cref="RequestMethod.Put"/> request.
	/// </summary>
	[Test]
	public void RequestBaseWithPutBody()
	{
		var body = """
			{ "data": "A random string or something." }
		""";

		var request = new RequestBaseMock(RequestMethod.Put, "test", "");
		request.Method.Should().Be(RequestMethod.Put);
		request.ContentType.Should().Be("test");
		request.Path.Should().Be("");

		request.SetBody(body);
		request.Body.Should().Be(body);
	}

	/// <summary>
	/// Tests that a request body cannot be set with a <see cref="RequestMethod.Get"/> request.
	/// </summary>
	[Test]
	public void RequestBaseWithNoBody()
	{
		var body = """
			{ "data": "A random string or something." }
		""";

		var request = new RequestBaseMock(RequestMethod.Get, "test", "");
		request.Method.Should().Be(RequestMethod.Get);
		request.ContentType.Should().Be("test");
		request.Path.Should().Be("");

		request.SetBody(body);
		request.Body.Should().Be(null);
	}
}
