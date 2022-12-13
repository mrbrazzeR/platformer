namespace GamePlay.Effect
{
    public class FrostEffectCreate:ICreateEffect
    {
        public IEffect GetEffect(int damage = 0, float time = 0)
        {
            return new FrostEffect(damage,time);
        }
    }
}