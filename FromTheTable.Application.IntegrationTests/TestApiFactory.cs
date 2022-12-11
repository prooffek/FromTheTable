using FromTheTable.Tests.Common;
using Microsoft.Extensions.Configuration;

namespace FromTheTable.Application.IntegrationTests;

public class TestApiFactory : BaseApiFactory
{
    public TestApiFactory(IConfiguration config) : base(config)
    {
    }
}