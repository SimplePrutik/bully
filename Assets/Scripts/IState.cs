public interface IState
{
    void EnterState();

    void ButtonHandler(string buttonName);
    
    // void EventHandler(params object [] args);

    void ExitState();
}