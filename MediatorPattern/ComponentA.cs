namespace MediatorPattern;

public interface IMediatorTest
{
    void HandleComponent(IComponent component, string msg);

}

public interface IComponent
{
    void Send(string msg);

    void Notify(string msg);
}

public class MediatorTest : IMediatorTest
{
    private readonly ComponentA _componentA;
    private readonly ComponentB _componentB;


    public void HandleComponent(IComponent component, string msg)
    {
        if (component == _componentA)
        {
            _componentB.Notify(msg);
        }
        if (component == _componentB)
        {
            _componentA.Notify(msg);
        }
    }
}


public class ComponentA : IComponent
{
    private readonly IMediatorTest _mediator;

    public ComponentA()
    {
        
    }

    public void Notify(string msg)
    {
        Console.WriteLine("Component A gets message: " + msg);

    }

    public void Send(string msg)
    {
        _mediator.HandleComponent(this, msg);
    }
}

public class ComponentB : IComponent
{
    private readonly IMediatorTest _mediator;

    public void Notify(string msg)
    {
        Console.WriteLine("Component B gets message: " + msg);
    }

    public void Send(string msg)
    {
        _mediator.HandleComponent(this, msg);
    }
}

