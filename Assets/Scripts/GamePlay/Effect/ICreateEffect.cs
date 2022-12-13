namespace GamePlay.Effect
{
    public interface ICreateEffect
    {
        IEffect GetEffect(int damage=0, float time = 0);
    }
}