using UnityEngine;

namespace GamePlay.Bot
{
    public abstract class BotState : MonoBehaviour
    {
        public abstract BotState RunCurrentState();
    }
}
