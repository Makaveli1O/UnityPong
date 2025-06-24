using UnityEngine;
using Assets.Scripts.SharedKernel;
using Assets.Scripts.Blocks;
using Assets.Scripts.GameHandler;
using System.Collections;
using Assets.Scripts.Level;


public class GameBootstrapper : MonoBehaviour
{
    private BlockFactory _blockFactory;
    private IBlockBehaviourResolver _blockBehaviourResolver;
    private BlockWinConditionCounter _blockCounter;
    private ISceneLoader _sceneLoader;
    private LevelDesigner _levelDesigner;
    [SerializeField] GameObject _levelDesignerPrefab;

    void Awake()
    {
        _blockFactory = GetComponent<BlockFactory>();
        _blockBehaviourResolver = new BlockColourBehaviourResolver();
        _blockCounter = new BlockWinConditionCounter();
        _sceneLoader = GetComponent<SceneLoader>();
        _levelDesigner = GetComponent<LevelDesigner>();

        RegisterServices();
    }

    void Start()
    {
        Instantiate(_levelDesignerPrefab);
    }

    private void RegisterServices()
    {
        SimpleServiceLocator.Register<IBlockFactory>(_blockFactory);
        SimpleServiceLocator.Register<IBlockBehaviourResolver>(_blockBehaviourResolver);
        SimpleServiceLocator.Register<IBlockCounter>(_blockCounter);
        SimpleServiceLocator.Register<IGameWinCondition>(_blockCounter);
        SimpleServiceLocator.Register<ISceneLoader>(_sceneLoader);
        SimpleServiceLocator.Register<ILevelDesigner>(_levelDesigner);
    }
}
