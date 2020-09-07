using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateMachine
{
    private List<State> _states;

    private State currentState;

    public StateMachine()
    {
        _states = new List<State>();
    }
        

    public void AddState(State state)
    {
        if (_states.All(x => x.stateName != state.stateName))
            _states.Add(state);
    }

    public void ButtonHandler(string buttonName) => currentState.ButtonHandler(buttonName);
    
    // public void EventHandler(params object[] args) => currentState.EventHandler(args);

    public void SetState(string stateName)
    {
        var state = _states.FirstOrDefault(x => x.stateName.Equals(stateName));
        if (state != null)
        {
            currentState?.ExitState();
            currentState = state;
            currentState.EnterState();
        }
        else
            Debug.LogWarning("Incorrect state name");
    }
    
    
    
}