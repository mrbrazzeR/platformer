using UnityEngine;

namespace GamePlay.Effect
{
    public class NormalEffect:IEffect
    {
        private readonly int _damage;
        public void Executed(GameObject gameObj)
        {
            gameObj.GetComponent<IEarnEffect>().EarnEffected(_damage);
        }
        public NormalEffect(int damage)
        {
            _damage = damage;
        }
    }
}