namespace GamePlay.Effect
{
    public class FireEffectCreate:ICreateEffect
    {
        public IEffect GetEffect(int damage = 0, float time = 0)
        {
            return new FireEffect(damage,time);
        }
    }
}