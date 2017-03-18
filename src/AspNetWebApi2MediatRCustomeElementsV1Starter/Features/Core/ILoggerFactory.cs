using System.Collections.Generic;

namespace AspNetWebApi2MediatRCustomeElementsV1Starter.Features.Core
{
    public interface ILoggerFactory
    {
        ILogger CreateLogger(string categoryName);

        List<ILoggerProvider> GetProviders();
    }
}
