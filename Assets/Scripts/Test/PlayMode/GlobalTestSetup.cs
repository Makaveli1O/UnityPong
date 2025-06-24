using Assets.Scripts.SharedKernel;
using NUnit.Framework;
using UnityEngine;
using Assets.Scripts.Blocks;
using System.Reflection;
using UnityEngine.SceneManagement;
using Unity;

[SetUpFixture]
public class GlobalTestSetup
{
    [OneTimeSetUp]
    public void RegisterGlobalServices()
    {
        // Register in ServiceLocator
        SimpleServiceLocator.Clear();
        SetupServiceLocator_BlockFactory();
    }

    [OneTimeTearDown]
    public void TearDownGlobalServices()
    {
        SimpleServiceLocator.Clear();
    }

    private void SetupServiceLocator_BlockFactory()
    {
        // Load prefab
        var blockPrefab = Resources.Load<GameObject>("Prefabs/Blocks/Block");
        Assert.IsNotNull(blockPrefab, "Global Setup: Block prefab not found.");

        //load behaviour resolver
        var behaviourResolver = new BlockColourBehaviourResolver();
        Assert.IsNotNull(behaviourResolver, "Global Setup: Behaviour resolver not found.");

        //win condition register
        var blockCounter = new BlockWinConditionCounter();
        SimpleServiceLocator.Register<IBlockCounter>(blockCounter);

        // Since it is a dependency for the factory, we register it first
        SimpleServiceLocator.Register<IBlockBehaviourResolver>(behaviourResolver);

        // Create factory
        var factoryGO = new GameObject("BlockFactory");
        var factory = factoryGO.AddComponent<BlockFactory>();
        typeof(BlockFactory)
            .GetField("_blockPrefab", BindingFlags.NonPublic | BindingFlags.Instance)
            .SetValue(factory, blockPrefab);
        typeof(BlockFactory)
            .GetField("_resolver", BindingFlags.NonPublic | BindingFlags.Instance)
            .SetValue(factory, behaviourResolver);

        // Register Factory in ServiceLocator
        SimpleServiceLocator.Register<IBlockFactory>(factory);
        
    }
}
