namespace AspNetWebApi2MediatRCustomeElementsV1Starter.Features.Core
{
    public interface ILoggerProvider
    {
        ILogger CreateLogger(string name);
    }
}
