using UnityEngine;
using Assets.Scripts.SharedKernel;
using Assets.Scripts.Blocks;

public class GameBootstrapper : MonoBehaviour
{
    private BlockFactory _blockFactory;
    private IBlockBehaviourResolver _blockBehaviourResolver;

    void Awake()
    {
        _blockFactory = GetComponent<BlockFactory>();
        _blockBehaviourResolver = new HardcodedResolver(); //TODO maybe make "HARDCODED" more flxible
        RegisterServices();
    }

    private void RegisterServices()
    {
        SimpleServiceLocator.Register<IBlockFactory>(_blockFactory);
        SimpleServiceLocator.Register<IBlockBehaviourResolver>(new HardcodedResolver());
        // Register other services here
    }
}
