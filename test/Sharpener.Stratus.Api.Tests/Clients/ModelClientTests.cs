// The Sharpener project licenses this file to you under the MIT license.

using Sharpener.Rest.Factories;
using Sharpener.Stratus.Api.Clients;
using Shouldly;
using Xunit;

namespace Sharpener.Stratus.Api.Tests.Clients;

public class ModelClientTests
{
    private readonly IHttpClientFactory _clientFactory;

    public ModelClientTests()
    {
        _clientFactory = new SharpenerHttpClientFactory();
    }

    [Fact]
    public async Task NarrativeTest()
    {
        const string appKey = "";
        const string modelId = "";
        const string reportId = "";
        const string viewId = "";

        var modelClient = new ModelClient(_clientFactory);

        var model = await modelClient.GetModel(appKey, modelId);
        model.IsSuccess.ShouldBeTrue();
        model.Value.ShouldNotBeNull();
        model.Value.Id.ShouldBe(modelId);

        var report = await modelClient.GetModelReport(appKey, modelId, reportId);
        report.IsSuccess.ShouldBeTrue();
        report.Value.ShouldNotBeNull();
        report.Value.ShouldNotBeNullOrWhiteSpace();
    }
}
