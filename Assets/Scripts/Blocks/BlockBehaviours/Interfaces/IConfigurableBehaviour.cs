namespace Assets.Scripts.Blocks
{
    public interface IConfigurableBehaviour<TConfig>
    {
        void Configure(TConfig config);
    }
}