namespace Assets.Scripts.Blocks
{
    public sealed class NoConfig
    {
        public static readonly NoConfig Instance = new();
        private NoConfig() { }
    }    
}