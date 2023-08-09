[![Build Status](https://github.com/lorenalexm/StrapiSharp/actions/workflows/testing.yml/badge.svg)](https://github.com/lorenalexm/StrapiSharp/actions/workflows/testing.yml/badge.svg)
![Nuget](https://img.shields.io/nuget/dt/StrapiSharp)
<a href="https://www.buymeacoffee.com/lorenalexm" target="_blank"><img src="https://cdn.buymeacoffee.com/buttons/default-orange.png" alt="Buy Me A Coffee" height="21" width="87"></a>

# StrapiSharp

This project builds a binding around the Strapi API to ease the communication between a .NET project and a Strapi backend; attempting to eliminate the need to write any `HttpClient` code yourself. A decision has been made at this time to only provide `string` results from requests; this allows you to bring your own JSON Serializer logic.


## Tech Stack

C# 7.0, NUnit, Fluent Assertions


## Documentation

At this time there is no formal documentation. I have tried to provide fairly detailed documentation comments throughout, but have not generated anything further at this point.


## Usage/Examples

Add the `StrapiSharp` package to your project by means of `dotnet add package StrapiSharp`, this will pull from [NuGet](https://www.nuget.org).

If desired, `StrapiSharp` can be registered with the dependency injection service builder. You can do that like so.

```cs
using StrapiSharp.Extensions;

// Below builder code already in place.
builder.Services.AddStrapiSharp("http://localhost:1337/api");
```

Basic example of querying a `posts` resource from Strapi.
```cs
using StrapiSharp;
using StrapiSharp.Requests;

var strapi = new Strapi("http://localhost:1337/api");
var request = new QueryRequest("posts");
var result = await strapi.ExecuteAsync(request);
Console.WriteLine(result);
```

Example of querying and filtering a `posts` example resource from Strapi.
```cs
using StrapiSharp;
using StrapiSharp.Enums;
using StrapiSharp.Requests;

var strapi = new Strapi("http://localhost:1337/api");
var request = new QueryRequest("posts");
request.Filter(FilterType.EqualTo, "id", "42");

var result = await strapi.ExecuteAsync(request);
Console.WriteLine(result);
```

Example of querying, filtering, and sorting a `posts` example resource from Strapi.
```cs
using StrapiSharp;
using StrapiSharp.Enums;
using StrapiSharp.Requests;

var strapi = new Strapi("http://localhost:1337/api");
var request = new QueryRequest("posts");
request.Filter(FilterType.GreaterThan, "id", "2");
request.Sort("slug", SortDirection.Descending);
request.LimitTo(3);

var result = await strapi.ExecuteAsync(request);
Console.WriteLine(result);
```

Example of catching a `StrapiRequestException` and extracting data from within.
```cs
using System.Text.Json;
using System.Text.Json.Serialization;
using StrapiSharp;
using StrapiSharp.Requests;
using StrapiSharp.Requests.Convenience;

try
{
	var login = new LoginRequest("username", "password");
	await strapi.ExecuteAsync(login);
}
catch(StrapiRequestException ex)
{
	Console.WriteLine(ex.Message);
	var error = JsonSerializer.Deserialize<ResponseModels.Response>(ex.Response)!.Error;
	Console.WriteLine($"{error!.Name} with status {error.Status}. {error!.Message}");
	Console.ReadLine();
}

namespace ResponseModels
{
	public partial class Response
	{
		[JsonPropertyName("data")]
		public object? Data { get; set; }

		[JsonPropertyName("error")]
		public Error? Error { get; set; }
	}

	public partial class Error
	{
		[JsonPropertyName("status")]
		public long Status { get; set; }

		[JsonPropertyName("name")]
		public string? Name { get; set; }

		[JsonPropertyName("message")]
		public string? Message { get; set; }
	}
}
```


## Running Tests

To run the test suite, run the following command

```bash
  dotnet test
```


## Acknowledgements

 - [Ricardo Rauber](https://github.com/ricardorauber) and his work on [StrapiSwift](https://github.com/ricardorauber/StrapiSwift) which was leaned upon heavily during development of StrapiSharp.


## License

[MIT](https://choosealicense.com/licenses/mit/)

