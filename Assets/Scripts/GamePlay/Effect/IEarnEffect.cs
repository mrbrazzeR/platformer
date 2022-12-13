using System.Collections;

namespace GamePlay.Effect
{
    public interface IEarnEffect
    {
        void EarnEffected(int damage = 0, float time = 0, AttackType attackType = AttackType.Normal);
    }
}