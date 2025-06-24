using UnityEngine;
using Assets.Scripts.SharedKernel;
using Assets.Scripts.Blocks;


public class GameBootstrapper : MonoBehaviour
{
    private BlockFactory _blockFactory;
    private IBlockBehaviourResolver _blockBehaviourResolver;
    private IBlockCounter _blockCounter;

    void Awake()
    {
        _blockFactory = GetComponent<BlockFactory>();
        _blockBehaviourResolver = new BlockColourBehaviourResolver();
        _blockCounter = new BlockWinConditionCounter();

        RegisterServices();
    }

    private void RegisterServices()
    {
        SimpleServiceLocator.Register<IBlockFactory>(_blockFactory);
        SimpleServiceLocator.Register<IBlockBehaviourResolver>(_blockBehaviourResolver);
        SimpleServiceLocator.Register<IBlockCounter>(_blockCounter);
    }
}
