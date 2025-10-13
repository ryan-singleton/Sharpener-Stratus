# Sharpener Stratus API NuGet

This package provides a simple set of tools for interacting with
the [GTP Stratus API](https://api.gtpstratus.com/index.html). It provides `Client` types that are used as first class
citizens that are grouped according to endpoints. For example, on the API, there are `Company` and `Model` sets of
endpoints (once referred to as controllers). So for each, there are now also `CompanyClient` and `ModelClient` types.

The tooling in this package contains data types for requests and responses, as well as putting the ceremony of each HTTP
request behind a client method. So, if you wanted to get a report for a specific model, you previously might have
written the code to create a `new HttpClient`, set the base url, set the headers, set the path and query parameters,
send the request, handle the various responses that may have been returned, and then finally multiplied the complexity
sevenfold by adding retry logic with appropriate backoff.

Now, assuming you have an `IHttpClientFactory` and your Stratus app key, it can look like this.

```csharp
var modelClient = new ModelClient(httpClientFactory);
var report = await modelClient.GetModelReport(appKey, modelId, reportId);

if(report.IsError) return null;
return report.Value;
```

Behind the scenes, it handles retry logic and http client management.

## Notes

This package currently is in the beginning phase. Standards of practice are being put into place so that future work can
be fast, since the Stratus API is quite large. As of this writing, there are only a handful of endpoints available.
However, it should be noted that the approach is settling in and there will soon be a full effort to fill them all out.

### Testing

For manual testing, a Blazor project has been created in order for developers to easily write interfaces to test the
endpoints that they create. The intent is to keep the sample web app as stock as possible, but libraries like Tailwind
may be added in the future. The backend is still C#, but it's much easier to toss something together in this framework
than it is in things like WPF or MAUI.

Standards as-yet to be determined:

- `Where` expression visitors will be useful for allowing a more programmatic interaction with the common "where" query
  that often appears in paginated responses. But for now, manually written where queries are supported.
- Composition will be leaned into heavily as we identify more and more "compositions" that are present in the Stratus
  API. That is to say, where you see repeated sets of associated properties, we will create an interface that outlines
  what those sets of properties or methods do, and then attribute them to the implementations. Ideally, I would like
  response types to have several interfaces apiece that they employ. For example
  `StratusFoo : IIdentified, IDated`

## Contributing

If you would like to contribute, please create an issue in the GitHub repository and wait for feedback. If it is
approved, you can create a new branch from that ticket and then create a PR when complete. Preference between rebase and
merge isn't very strong, just be pragmatic in your choices. Please be as detailed in your PR as possible, including
writing comments on your own PR to give hints and guidance for the code review. Thank you.

