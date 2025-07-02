using UnityEngine;
using Assets.Scripts.SharedKernel;
using Assets.Scripts.Blocks;
using Assets.Scripts.GameHandler;
using Assets.Scripts.Level;
using Assets.Scripts.Score;


public class GameBootstrapper : MonoBehaviour
{
    private BlockFactory _blockFactory;
    private BlockWinConditionCounter _blockCounter;
    private SceneLoader _sceneLoader;
    private LevelDesigner _levelDesigner;
    [SerializeField] private SoundPlayer _soundPlayerPrefab;
    private SoundPlayer _soundPlayerInstance;

    [SerializeField] private GameHandler _gameHandlerPrefab;
    private ScoreTracker _scoreTracker;
    private GameHandler _gameHandlerInstance;
    void Awake()
    {
        _blockFactory = GetComponent<BlockFactory>();
        _blockCounter = new BlockWinConditionCounter();
        _sceneLoader = GetComponent<SceneLoader>();
        _levelDesigner = GetComponent<LevelDesigner>();
        _scoreTracker = GetComponent<ScoreTracker>();


        RegisterServices();

        _gameHandlerInstance = Instantiate(_gameHandlerPrefab);
        _soundPlayerInstance = Instantiate(_soundPlayerPrefab);

        RegisterInstantiatedServices();
    }

    private void RegisterServices()
    {
        SimpleServiceLocator.Register<IBlockFactory>(_blockFactory);
        SimpleServiceLocator.Register<IBlockCounter>(_blockCounter);
        SimpleServiceLocator.Register<IGameWinCondition>(_blockCounter);
        SimpleServiceLocator.Register<ISceneLoader>(_sceneLoader);
        SimpleServiceLocator.Register<ILevelDesigner>(_levelDesigner);
        SimpleServiceLocator.Register<IScoreTracker>(_scoreTracker);
    }

    private void RegisterInstantiatedServices()
    {
        SimpleServiceLocator.Register<IGameStateController>(_gameHandlerInstance);
        SimpleServiceLocator.Register<ISoundPlayer>(_soundPlayerInstance);
    }
}
