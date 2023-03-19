using StrapiSharp.Enums;
using StrapiSharp.Models;

namespace StrapiSharp.Requests;

/// <summary>
/// The base class that all requests should inherit from.
/// </summary>
public abstract class RequestBase
{
	public RequestMethod Method { get; private set; }
	public string ContentType { get; private set; }
	public string Path { get; private set; }
	public List<RequestFilter> Filters { get; private set; }
	public string? Body { get; private set; }

	/// <summary>
	/// Checks if the request can accept one or more <see cref="RequestFilter"/>.
	/// </summary>
	public bool CanSetFilters
	{
		get
		{
			return Method == RequestMethod.Get;
		}
	}

	/// <summary>
	/// Checks if the request supports sending a body string.
	/// </summary>
	public bool CanSetBody
	{
		get
		{
			return Method == RequestMethod.Post || Method == RequestMethod.Put;
		}
	}

	/// <summary>
	/// Sets the properties for furture requests.
	/// </summary>
	/// <param name="method">The <see cref="RequestMethod"/> of this request.</param>
	/// <param name="contentType">The Strapi content type</param>
	/// <param name="path">The path on the server that this request will be sent to.</param>
	/// <param name="filters">Any content specific filters as a <see cref="string"/> array to be sent with the request.</param>
	public RequestBase(RequestMethod method, string contentType, string path = "", List<RequestFilter>? filters = null)
	{
		Method = method;
		ContentType = contentType;
		Path = path;
		Filters = filters ?? new List<RequestFilter>();
	}

	/// <summary>
	/// Sets the body for any <see cref="RequestMethod.Post"/> and <see cref="RequestMethod.Put"/> requests.
	/// </summary>
	/// <param name="body"></param>
	public void SetBody(string body)
	{
		if(CanSetBody == false)
		{
			return;
		}
		Body = body;
	}

	/// <summary>
	/// Sets a filter by key and value.
	/// </summary>
	/// <param name="type">The <see cref="FilterType"/> as a string.</param>
	/// <param name="field">Field for the filter to effect.</param>
	/// <param name="value">Value to filter against.</param>
	private void SetFilter(string type, string field, string value)
	{
		RequestFilter filter = new RequestFilter { Type = type, Field = field, Value = value };
		Filters.Add(filter);
	}

	/// <summary>
	/// Removes all stored filters for the request.
	/// </summary>
	private void RemoveAllFilters()
	{
		Filters.Clear();
	}

	/// <summary>
	/// Filters a <see cref="RequestMethod.Get"/> request with the preconstructed <see cref="RequestFilter"/>.
	/// </summary>
	/// <param name="filter">A constructred <see cref="RequestFilter"/> object.</param>
	public void Filter(RequestFilter filter)
	{
		if (CanSetFilters == false)
		{
			return;
		}
		Filters.Add(filter);
	}

	/// <summary>
	/// Filters a <see cref="RequestMethod.Get"/> request by the given <see cref="FilterType"/>.
	/// </summary>
	/// <param name="type">What filter should be applied?</param>
	/// <param name="field">The field to be filtered.</param>
	/// <param name="value">The value to filter against.</param>
	public void Filter(FilterType type, string field, string value)
	{
		if (CanSetFilters == false)
		{
			return;
		}

		switch (type)
		{
			case FilterType.In:
				SetFilter("$in", field, value);
				break;

			case FilterType.NotIn:
				SetFilter("$notIn", field, value);
				break;

			case FilterType.EqualTo:
				SetFilter("$eq", field, value);
				break;

			case FilterType.NotEqualTo:
				SetFilter("$ne", field, value);
				break;

			case FilterType.LessThan:
				SetFilter("$lt", field, value);
				break;

			case FilterType.LessThanOrEqualTo:
				SetFilter("$lte", field, value);
				break;

			case FilterType.GreaterThan:
				SetFilter("$gt", field, value);
				break;

			case FilterType.GreaterThanOrEqualTo:
				SetFilter("$gte", field, value);
				break;

			case FilterType.Contains:
				SetFilter("$contains", field, value);
				break;

			case FilterType.DoesNotContain:
				SetFilter("$notContains", field, value);
				break;

			case FilterType.StartsWith:
				SetFilter("$startsWith", field, value);
				break;

			case FilterType.EndsWith:
				SetFilter("$endsWith", field, value);
				break;

			case FilterType.IsNull:
				SetFilter("$null", field, value);
				break;

			case FilterType.IsNotNull:
				SetFilter("$notNull", field, value);
				break;
		}
	}

	/// <summary>
	/// Sets the starting index for a request in a <see cref="RequestMethod.Get"/> request.
	/// </summary>
	/// <param name="index">Value of the starting index.</param>
	public void StartingAt(int index)
	{
		SetFilter("pagination", "start", index.ToString());
	}

	/// <summary>
	/// Sets the limit for the number of returned items in a <see cref="RequestMethod.Get"/> request.
	/// The maximum value for limits are set on the Strapi server, if you are running into issue with fewer results than expected check there.
	/// </summary>
	/// <param name="count">Value of the limit.</param>
	public void LimitTo(int count)
	{
		SetFilter("pagination", "limit", count.ToString());
	}

	/// <summary>
	/// Sorts a field for a <see cref="RequestMethod.Get"/> request.
	/// </summary>
	/// <param name="field">The field to be sorted.</param>
	/// <param name="sort">Which direction should the <see cref="SortDirection"/> be in?</param>
	public void Sort(string field, SortDirection sort)
	{
		var direction = (sort == SortDirection.Ascending) ? "asc" : "desc";
		SetFilter("sort", field, direction);
	}
}
