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
be fast, since the Stratus API is quite large. As of this writing, there are only 3 endpoints available. Ping, Get Model
by ID, and Get Model Report by their IDs. However, it should be noted that the approach is settling in and there will
soon be a full effort to fill them all out.

Standards as-yet to be determined:

- Auto camel casing of some properties.
    - This may seem simple. It's not. You can set `System.Text.Json` to globally use camel casing on DTOs, but I'm not
      interested in forcing that behavior throughout the entire app stack. I will probably be creating a class or
      property attribute that automatically camel cases properties. For the meantime, I'm explicitly calling
      `JsonPropertyName` and providing it. But I want the data types in library to feel first class. So the data types
      themselves will not be using camel case.
- Testing is very immature
    - For the moment, you can test your work in the test project by manually supplying your app key and the IDs you need
      for the calls you want. However, these test projects should be used for unit and integration testing later on. I
      intend to build a thin UI where a developer can input the values that they want to test against the classes and
      endpoints that they are contributing. But for starting out, it's a little backwards.
- Composition will be leaned into heavily as we identify more and more "compositions" that are present in the Stratus
  API. That is to say, where you see repeated sets of associated properties, we will create an interface that outlines
  what those sets of properties or methods do, and then attribute them to the implementations. Ideally, I would like
  response types to have several interfaces apiece that they employ. For example
  `StratusFoo : IHasId, IDateTimeLifecycle`

## Contributing

This is the early stages of this project, so it may not be the best time yet to get involved, but as the shape of this
effort begins to flesh out, you may find yourself wanting to contribute. It is most welcome. It is a large API and will
likely require responsiveness on our part so that we can stay up to date with the current version of the API. Help will
be most appreciated as the maintainability of this project grows more imposing.

