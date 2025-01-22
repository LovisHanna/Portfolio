using MediatorPattern;

namespace Portfolio.Api.Handlers;

public class GetHandler : IHandler
{
    public Type ConcreteRequestType => typeof(GetHandlerRequest);

    public Task<IHandleResponse> Handle(IHandlerRequest request)
    {
        throw new NotImplementedException();
    }
}
public class GetHandlerRequest : IHandlerRequest
{
    public string Id { get; set; }
}
public class GetHandlerResponse : IHandleResponse
{
    public Book Book { get; set; }
}
