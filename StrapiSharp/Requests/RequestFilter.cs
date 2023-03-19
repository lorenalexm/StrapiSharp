using StrapiSharp.Enums;

namespace StrapiSharp.Requests;

/// <summary>
/// The structure for any filtering of requests.
/// </summary>
public struct RequestFilter
{
	public string Type { get; set; }
	public string Field { get; set; }
	public string Value { get; set; }
}
