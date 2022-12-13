using UnityEngine;

namespace GamePlay.Effect
{
    public static class ClientEffect
    {
        public static void ClientMethod(ICreateEffect factory, CharacterStats characterStats, GameObject gameObj)
        {
            var detect = factory.GetEffect(characterStats.damage, characterStats.timeEffect);
            detect.Executed(gameObj);
        }
    }
}