// The Sharpener project licenses this file to you under the MIT license.

using Sharpener.Rest.Factories;

namespace Sharpener.Stratus.Api.Tests.Clients;

public class ModelClientTests
{
    private readonly IHttpClientFactory _clientFactory;

    public ModelClientTests()
    {
        _clientFactory = new SharpenerHttpClientFactory();
    }
}
