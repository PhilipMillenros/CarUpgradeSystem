using System;
using UnityEngine;
using UnityEngine.AI;

namespace Vehicle
{
    public enum State { Searching, Following, Idle}
    public class CarAI : MonoBehaviour
    {
        public State state;
        [SerializeField] private Vector2 searchBorderEnd;
        [SerializeField] private Vector2 searchBorderStart;
        [SerializeField] private NavigationAI navigation;
        public Transform target;
        private void Update()
        {
            switch (state)
            {
                case State.Searching :
                    
                    break;
                case State.Following :
                    navigation.SetDestination(target.position);
                    break;
                case State.Idle :
                    break;
            }
        }
    }
}