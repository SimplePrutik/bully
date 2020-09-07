
public abstract class State : IState
{
    public string stateName;

    protected Unit unit;
    
    
    public virtual void EnterState()
    {
        
    }

    public virtual void ButtonHandler(string buttonName)
    {
        
    }
    

    public virtual void ExitState()
    {
        
    }
    
    
}