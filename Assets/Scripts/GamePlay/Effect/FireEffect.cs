using UnityEngine;

namespace GamePlay.Effect
{
    public class FireEffect : IEffect
    {
        private readonly int _damage;
        private readonly float _time;
        private const AttackType AttackType = Effect.AttackType.Fire;

        public void Executed(GameObject gameObj)
        {
            gameObj.GetComponent<IEarnEffect>().EarnEffected(_damage, _time, AttackType);
        }

        public FireEffect(int damage, float time)
        {
            _damage = damage;
            _time = time;
        }
    }
}