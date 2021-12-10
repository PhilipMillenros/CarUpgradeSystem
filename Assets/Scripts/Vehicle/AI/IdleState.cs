using UnityEngine;

namespace Vehicle
{
    [CreateAssetMenu(fileName = "IdleState", menuName = "FSM/States/Idle", order = 1)]
    public class IdleState : FsmState
    {
        public override bool EnterState()
        {
            base.EnterState();
            Debug.Log("Entered idle");
            return true;
        }

        public override void UpdateState()
        {
            Debug.Log("Updating idle state");
        }

        public override bool ExitState()
        {
            base.EnterState();
            Debug.Log("Exiting idle state");
            return true;
        }
    }
}