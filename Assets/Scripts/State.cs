
public abstract class State : IState
{
    public string stateName;

    protected Unit unit;
    
    public virtual void EnterState()
    {
        throw new System.NotImplementedException();
    }

    public virtual void ButtonHandler(string buttonName)
    {
        throw new System.NotImplementedException();
    }
    
    // public virtual void EventHandler(params object[] args)
    // {
    //     throw new System.NotImplementedException();
    // }

    public virtual void ExitState()
    {
        throw new System.NotImplementedException();
    }
    
    
}