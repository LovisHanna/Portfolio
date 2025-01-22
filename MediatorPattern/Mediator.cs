
namespace MediatorPattern;

public interface IMediator
{
    void HandleRequest(IHandlerRequest request);
}

public class RequestFromController
{
    
}

public interface IHandlerRequest
{

}
public interface IHandleResponse
{

}
public interface IHandler
{
    Task<IHandleResponse> Handle(IHandlerRequest request);
    Type ConcreteRequestType { get; }
}
public class Mediator : IMediator
{
    private readonly IEnumerable<IHandler> _handlers;

    public Mediator(IEnumerable<IHandler> handlers)
    {
        _handlers = handlers ?? throw new ArgumentNullException(nameof(handlers));
    }

    public void HandleRequest(IHandlerRequest request)
    {
        Type type = request.GetType();
        foreach (var handler in _handlers)
        {
            if(handler.ConcreteRequestType == type)
            {
                handler.Handle(request);
            }
        }
    }
}
