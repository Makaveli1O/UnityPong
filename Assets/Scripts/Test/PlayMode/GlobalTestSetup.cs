using System.Collections;
using Assets.Scripts.Blocks;
using Assets.Scripts.SharedKernel;
using NUnit.Framework;
using UnityEngine;

[SetUpFixture]
public class GlobalTestSetup
{
    [OneTimeSetUp]
    public void RegisterGlobalServices()
    {
        Debug.Log("Global Setup: Registering services for integration tests...");
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

        // Create factory
        var factoryGO = new GameObject("BlockFactory");
        var factory = factoryGO.AddComponent<BlockFactory>();
        typeof(BlockFactory)
            .GetField("_blockPrefab", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(factory, blockPrefab);

        // Register factory in ServiceLocator
        SimpleServiceLocator.Register<IBlockFactory>(factory);
    }
}
