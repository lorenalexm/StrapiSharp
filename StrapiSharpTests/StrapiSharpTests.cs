using Strapi = StrapiSharp.StrapiSharp;

namespace StrapiSharpTests;

public class StrapiSharpTests
{
	//private Strapi? _strapi;
	private Strapi? _strapi;

	/// <summary>
	/// Sets properties before each test.
	/// </summary>
	[SetUp]
	public void SetUp()
	{
		_strapi = new Strapi("http://localhost");
	}

	/// <summary>
	/// Releases properties before each test.
	/// </summary>
	[TearDown]
	public void TearDown()
	{
		_strapi = null;
	}

	/// <summary>
	/// Tests building a URI with no additional filters.
	/// </summary>
	[Test]
	public void BuildURIWithNoFilters()
	{
		var request = new FetchRequest("testing", 1);
		var uri = _strapi!.BuildURI(request);
		uri.Should().Be("http://localhost/testing/1");
	}

	/// <summary>
	/// Tests building a URI with a single filter.
	/// </summary>
	[Test]
	public void BuildURIWithOneFilter()
	{
		var request = new QueryRequest("testing");
		request.Filter(FilterType.LessThan, "number", "500");
		var uri = _strapi!.BuildURI(request);
		uri.Should().Be("http://localhost/testing?filters[number][$lt]=500");
	}

	/// <summary>
	/// Tests building a URI with multiple filters.
	/// </summary>
	[Test]
	public void BuildURIWithMultipleFilters()
	{
		var request = new QueryRequest("testing");
		request.Filter(FilterType.LessThan, "number", "500");
		request.Filter(FilterType.IsNotNull, "name", "");
		var uri = _strapi!.BuildURI(request);
		uri.Should().Be("http://localhost/testing?filters[number][$lt]=500&filters[name][$notNull]");
	}

	/// <summary>
	/// Tests building a URI with <see cref="FilterType.In"/> filters.
	/// </summary>
	[Test]
	public void BuildURIWithInFilters()
	{
		var request = new QueryRequest("testing");
		request.Filter(FilterType.In, "id", "3");
		request.Filter(FilterType.In, "id", "6");
		var uri = _strapi!.BuildURI(request);
		uri.Should().Be("http://localhost/testing?filters[id][$in][0]=3&filters[id][$in][1]=6");
	}

	/// <summary>
	/// Tests building a URI with <see cref="FilterType.In"/> filters.
	/// </summary>
	[Test]
	public void BuildURIWithNotInFilters()
	{
		var request = new QueryRequest("testing");
		request.Filter(FilterType.NotIn, "id", "3");
		request.Filter(FilterType.NotIn, "id", "6");
		var uri = _strapi!.BuildURI(request);
		uri.Should().Be("http://localhost/testing?filters[id][$notIn][0]=3&filters[id][$notIn][1]=6");
	}

	/// <summary>
	/// Tests building a URI with descending sorting.
	/// </summary>
	[Test]
	public void BuildURIWithSorting()
	{
		var request = new QueryRequest("testing");
		request.Sort("id", SortDirection.Descending);
		var uri = _strapi!.BuildURI(request);
		uri.Should().Be("http://localhost/testing?sort[0]=id:desc");
	}

	/// <summary>
	/// Tests building a URI with population.
	/// </summary>
	[Test]
	public void BuildURIWithPopulation()
	{
		var request = new QueryRequest("testing");
		request.Populate("*");
		var uri = _strapi!.BuildURI(request);
		uri.Should().Be("http://localhost/testing?populate[0]=*");
	}

	/// <summary>
	/// Tests building a URI with a starting offset and return limits.
	/// </summary>
	[Test]
	public void BuildURIWithOffsetAndLimit()
	{
		var request = new QueryRequest("testing");
		request.StartingAt(25);
		request.LimitTo(3);
		var uri = _strapi!.BuildURI(request);
		uri.Should().Be("http://localhost/testing?pagination[start]=25&pagination[limit]=3");
	}
}
