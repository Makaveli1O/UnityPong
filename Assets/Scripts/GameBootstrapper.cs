using UnityEngine;
using Assets.Scripts.SharedKernel;
using Assets.Scripts.Blocks;
using Game;

public class GameBootstrapper : MonoBehaviour
{
    private BlockFactory _blockFactory;
    private IBlockBehaviourResolver _blockBehaviourResolver;
    private SceneLoader _sceneLoader;

    void Awake()
    {
        _sceneLoader = GetComponent<SceneLoader>();
        _blockFactory = GetComponent<BlockFactory>();
        _blockBehaviourResolver = new BlockColourBehaviourResolver(); //TODO maybe make "HARDCODED" more flxible
        RegisterServices();
    }

    private void RegisterServices()
    {
        SimpleServiceLocator.Register<IGameWinCondition>(new BlockWinCondition());
        SimpleServiceLocator.Register<SceneLoader>(_sceneLoader);
        SimpleServiceLocator.Register<IBlockFactory>(_blockFactory);
        SimpleServiceLocator.Register<IBlockBehaviourResolver>(_blockBehaviourResolver);
    }
}
