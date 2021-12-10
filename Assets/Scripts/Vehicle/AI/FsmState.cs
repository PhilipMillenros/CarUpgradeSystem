using System;
using UnityEngine;

public enum ExecutionState
{
    None,
    Active,
    Completed,
    Terminated
}

namespace Vehicle
{
    public abstract class FsmState : ScriptableObject
    {
        public ExecutionState ExecutionState { get; protected set; }

        public void OnEnable()
        {
            ExecutionState = ExecutionState.None;
        }

        public virtual bool EnterState()
        {
            ExecutionState = ExecutionState.Active;
            return true;
        }

        public abstract void UpdateState();
        
        public virtual bool ExitState()
        {
            ExecutionState = ExecutionState.Completed;
            return true;
        }
    }
}