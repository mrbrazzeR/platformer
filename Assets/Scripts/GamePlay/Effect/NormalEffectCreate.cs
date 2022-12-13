namespace GamePlay.Effect
{
    public class NormalEffectCreate:ICreateEffect

    {
        public IEffect GetEffect(int damage = 0, float time = 0)
        {
            return new NormalEffect(damage);
        }
    }
}