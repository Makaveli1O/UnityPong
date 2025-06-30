using UnityEngine;
using Assets.Scripts.SharedKernel;
using Assets.Scripts.Blocks;
using Assets.Scripts.GameHandler;
using Assets.Scripts.Level;
using Assets.Scripts.Sound;


public class GameBootstrapper : MonoBehaviour
{
    private BlockFactory _blockFactory;
    private BlockWinConditionCounter _blockCounter;
    private SceneLoader _sceneLoader;
    private LevelDesigner _levelDesigner;
    [SerializeField] private SoundPlayer _soundPlayer;

    void Awake()
    {
        _blockFactory = GetComponent<BlockFactory>();
        _blockCounter = new BlockWinConditionCounter();
        _sceneLoader = GetComponent<SceneLoader>();
        _levelDesigner = GetComponent<LevelDesigner>();

        if (_soundPlayer == null) throw new System.Exception("SoundPlayer is not assigned in the inspector.");

        RegisterServices();
    }

    private void RegisterServices()
    {
        SimpleServiceLocator.Register<IBlockFactory>(_blockFactory);
        SimpleServiceLocator.Register<IBlockCounter>(_blockCounter);
        SimpleServiceLocator.Register<IGameWinCondition>(_blockCounter);
        SimpleServiceLocator.Register<ISceneLoader>(_sceneLoader);
        SimpleServiceLocator.Register<ILevelDesigner>(_levelDesigner);
        SimpleServiceLocator.Register<ISoundPlayer>(_soundPlayer);
    }
}
