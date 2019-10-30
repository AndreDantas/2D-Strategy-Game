using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UtilityLibrary;
public class StateMachine : MonoBehaviour
{

    [ShowInInspector]
    public virtual State CurrentState
    {
        get
        {
            if (_currentState != null && _currentState.Count > 0)
                return _currentState.SafePeek();
            return null;
        }
        //set { Transition(value); }
    }
    [ShowInInspector, ReadOnly]
    protected Stack<State> _currentState = new Stack<State>();
    protected bool _inTransition;

    protected virtual void Awake()
    {
        _currentState = new Stack<State>();

    }

    public virtual void ClearStates()
    {
        if (_inTransition)
            return;
        _inTransition = true;

        if (_currentState?.Count > 0)
            _currentState?.Pop()?.Exit();

        _currentState.Clear();
    }

    public virtual T GetState<T>() where T : State
    {
        T target = GetComponent<T>();
        if (target == null)
            target = gameObject.AddComponent<T>();
        return target;
    }

    public virtual T ChangeState<T>(bool removeCurrent = true) where T : State
    {
        var state = GetState<T>();
        if (removeCurrent)
            Transition(state);
        else
            AddState(state);
        return state;
    }

    protected virtual void Transition(State value)
    {
        if (_currentState?.SafePeek() == value || _inTransition)
            return;
        _inTransition = true;

        if (_currentState?.Count > 0)
            _currentState?.Pop()?.Exit();


        _currentState?.Push(value);

        if (_currentState?.Count > 0)
            _currentState?.SafePeek()?.Enter();

        _inTransition = false;
    }

    public virtual void AddState(State value)
    {
        if (_currentState?.SafePeek() == value || _inTransition)
            return;
        _inTransition = true;

        if (_currentState?.Count > 0)
            _currentState?.SafePeek()?.Exit();

        _currentState?.Push(value);

        if (_currentState?.Count > 0)
            _currentState?.SafePeek()?.Enter();

        _inTransition = false;
    }

    public virtual void RemoveState()
    {
        if (_inTransition)
            return;
        _inTransition = true;
        if (_currentState != null)
            _currentState?.Pop()?.Exit();

        if (_currentState?.Count > 0)
            _currentState?.SafePeek()?.Enter();

        _inTransition = false;
    }
}
