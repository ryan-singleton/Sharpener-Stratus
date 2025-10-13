// The Sharpener project licenses this file to you under the MIT license.

using Sharpener.Rest.Factories;
using Sharpener.Stratus.Api.Clients;
using Shouldly;
using Xunit;

namespace Sharpener.Stratus.Api.Tests.Clients;

public class PingClientTests
{
    private readonly IHttpClientFactory _clientFactory;

    public PingClientTests()
    {
        _clientFactory = new SharpenerHttpClientFactory();
    }
}
