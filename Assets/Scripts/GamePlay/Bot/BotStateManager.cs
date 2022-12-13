using System;
using UnityEngine;

namespace GamePlay.Bot
{
    public class BotStateManager : MonoBehaviour
    {
        [SerializeField] private BotState currentState;

        private void Update()
        {
            RunStateMachine();
        }

        private void RunStateMachine()
        {
            var nextState = currentState?.RunCurrentState();
            if (nextState != null)
            {
                SwitchToNextState(nextState);
            }
        }

        private void SwitchToNextState(BotState nextState)
        {
            currentState = nextState;
        }
    }
}