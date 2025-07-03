namespace Assets.Scripts.GameHandler
{
    public interface ISceneLoader
    {
        public void LoadScene(string sceneName);
        public bool IsCurrentSceneLevel();
    }
}