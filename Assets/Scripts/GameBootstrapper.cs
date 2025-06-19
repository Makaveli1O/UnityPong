using UnityEngine;
using Assets.Scripts.SharedKernel;
using Assets.Scripts.Blocks;

public class GameBootstrapper : MonoBehaviour
{
    private BlockFactory _blockFactory;

    void Awake()
    {
        _blockFactory = GetComponent<BlockFactory>();
        RegisterServices();
    }

    private void RegisterServices()
    {
        SimpleServiceLocator.Register<IBlockFactory>(_blockFactory);
        // Register other services here
    }
}
