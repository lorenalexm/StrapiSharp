namespace StrapiSharp.Enums;

/// <summary>
/// The filters available to all <see cref="RequestMethod.Get"/> requests.
/// </summary>
public enum FilterType
{
	In,
	NotIn,
	EqualTo,
	NotEqualTo,
	LessThan,
	LessThanOrEqualTo,
	GreaterThan,
	GreaterThanOrEqualTo,
	Contains,
	DoesNotContain,
	StartsWith,
	EndsWith,
	IsNull,
	IsNotNull
}
