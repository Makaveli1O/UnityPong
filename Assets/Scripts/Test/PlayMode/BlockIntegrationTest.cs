/*using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Assets.Scripts.Blocks;
using Unity.Mathematics;
using System.Reflection;
using System.Linq;
using System;
using Assets.Scripts.SharedKernel;

public class BlockIntegrationTest
{
    private const string collisionBehavioursField = "_collisionBehaviours";
    private const string updateBehavioursField = "_updateBehaviours";
    private GameObject blockSpawnerObject;
    private BlockSpawner blockSpawner;
    [SerializeField] public GameObject blockPrefab;

    [SetUp]
    public void SetUp()
    {
        // Clear and register services BEFORE creating BlockSpawner
        SimpleServiceLocator.Clear();

        // Load prefab
        var blockPrefab = Resources.Load<GameObject>("Prefabs/Blocks/Block");
        Assert.IsNotNull(blockPrefab, "Global Setup: Block prefab not found.");

        var behaviourResolver = new BlockColourBehaviourResolver();
        Assert.IsNotNull(behaviourResolver);

        var blockCounter = new BlockWinConditionCounter();
        SimpleServiceLocator.Register<IBlockCounter>(blockCounter);
        SimpleServiceLocator.Register<IBlockBehaviourResolver>(behaviourResolver);

        var factoryGO = new GameObject("BlockFactory");
        var factory = factoryGO.AddComponent<BlockFactory>();
        typeof(BlockFactory)
            .GetField("_blockPrefab", BindingFlags.NonPublic | BindingFlags.Instance)
            .SetValue(factory, blockPrefab);
        typeof(BlockFactory)
            .GetField("_resolver", BindingFlags.NonPublic | BindingFlags.Instance)
            .SetValue(factory, behaviourResolver);
        SimpleServiceLocator.Register<IBlockFactory>(factory);

        // ✅ Now safe to add BlockSpawner (Awake will succeed)
        blockSpawnerObject = new GameObject("BlockSpawner");
        blockSpawner = blockSpawnerObject.AddComponent<BlockSpawner>();
    }

    [TearDown]
    public void TearDown()
    {
        UnityEngine.Object.Destroy(blockSpawnerObject);
        BlockWinConditionCounter counter = (BlockWinConditionCounter)SimpleServiceLocator.Resolve<IBlockCounter>();
        counter.ResetCounter();
    }

    [UnityTest]
    public IEnumerator SpawnEmptyBlock_ShouldPass()
    {
        SpawnEmptyBlock(new int2(0, 0));
        yield return null; // Wait for Start/Awake

        var spawnedBlocks = GameObject.FindGameObjectsWithTag("Block");
        Assert.IsTrue(spawnedBlocks.Length > 0, "No blocks were spawned on start.");
    }

    [UnityTest]
    public IEnumerator SpawnAndDestroyEmptyBlock_ShouldPass()
    {
        // Spawn a block
        var block = SpawnEmptyBlock(new int2(0, 0));
        yield return null; // Wait a frame for Start/Awake

        Assert.IsNotNull(block, "Block was not spawned successfully.");
        // Destroy the block
        blockSpawner.DestroyBlock(block);
        yield return null; // Wait a frame for destruction

        var remainingBlocks = GameObject.FindGameObjectsWithTag("Block");
        Assert.IsTrue(remainingBlocks.Length == 0, "Block was not destroyed successfully.");
    }

    [UnityTest]
    public IEnumerator BlockSpawner_RemovesBlocks_WhenDestroyed()
    {
        yield return null; // Wait for blocks to spawn

        var spawnedBlocks = GameObject.FindGameObjectsWithTag("Block");
        foreach (var block in spawnedBlocks)
        {
            UnityEngine.Object.Destroy(block);
        }
        yield return null;

        var remainingBlocks = GameObject.FindGameObjectsWithTag("Block");
        Assert.IsTrue(remainingBlocks.Length == 0, "Blocks were not removed after destruction.");
    }

    [UnityTest]
    public IEnumerator SpawnMultipleBlocks_ShouldSpawnCorrectNumber()
    {
        int spawnCount = 5;
        for (int i = 0; i < spawnCount; i++)
        {
            SpawnEmptyBlock(new int2(i, 0));
        }
        yield return null;

        var spawnedBlocks = GameObject.FindGameObjectsWithTag("Block");
        Assert.AreEqual(spawnCount, spawnedBlocks.Length, $"Expected {spawnCount} blocks to be spawned.");
    }

    [UnityTest]
    public IEnumerator Should_TriggerWinCondition_When_AllBlocksDestroyed()
    {
        BlockWinConditionCounter blockCounter = (BlockWinConditionCounter)SimpleServiceLocator.Resolve<IBlockCounter>();

        // spawn two blocks nd destroy them to trigger winning condition
        int spawnCount = 2;
        Assert.IsFalse(blockCounter.IsWinConditionMet());

        for (int i = 0; i < spawnCount; i++)
        {
            Block block = SpawnEmptyBlock(new int2(i, 0));
            blockSpawner.DestroyBlock(block);
        }

        
        Assert.IsTrue(blockCounter.IsWinConditionMet());
        yield return null;
    }

    [UnityTest]
    public IEnumerator DestroyBlock_NullReference_ShouldThrow()
    {
        Assert.Throws<System.Exception>(() => blockSpawner.DestroyBlock(null));
        yield return null;
    }

    [UnityTest]
    public IEnumerator SpawnBlock_WithCustomPosition_SetsCorrectTransform()
    {
        var position = new int2(3, 7);
        var block = SpawnEmptyBlock(position);
        yield return null;

        Assert.IsNotNull(block, "Block was not spawned.");
        Assert.AreEqual(position.x, Mathf.RoundToInt(block.transform.position.x), "Block X position mismatch.");
        Assert.AreEqual(position.y, Mathf.RoundToInt(block.transform.position.y), "Block Y position mismatch.");
    }

    [UnityTest]
    public IEnumerator DestroyAllBlocks_RemovesAllBlocks()
    {
        for (int i = 0; i < 3; i++)
        {
            SpawnEmptyBlock(new int2(i, 0));
        }
        yield return null;

        var spawnedBlocks = GameObject.FindGameObjectsWithTag("Block");
        foreach (var blockObj in spawnedBlocks)
        {
            Block block = blockObj.GetComponent<Block>();
            blockSpawner.DestroyBlock(block);
        }
        yield return null;

        var remainingBlocks = GameObject.FindGameObjectsWithTag("Block");
        Assert.AreEqual(0, remainingBlocks.Length, "Not all blocks were destroyed.");
    }

    [UnityTest]
    public IEnumerator SpawnedBlockColours_ShouldBeRenderedCorrectly()
    {
        int colourCount = BlockColour.GetValues(typeof(BlockColour)).Length;

        for (int i = 0; i < colourCount; i++)
        {
            Block block = blockSpawner.SpawnBlock(
                new BlockData(
                    null,
                    (BlockColour)i,
                    new int2(i, 0)
                )
            );

            var spriteRenderer = block.GetComponent<SpriteRenderer>();
            Assert.AreEqual(
                BlockColourBehaviourResolver.ToColour((BlockColour)i),
                spriteRenderer.color,
                "Block sprite color does not match BlockColour."
            );
        }

        yield return null;
    }

    [UnityTest]
    public IEnumerator SpawnRedBlockBehaviour_ShouldHaveExplode()
    {
        var block = blockSpawner.SpawnBlock(
            new BlockData(
                null,
                BlockColour.Red,
                new int2(0, 0)
            )
        );
        yield return null; // Wait for Start/Awake

        Assert.IsNotNull(block, "Block was not spawned successfully.");

        // Check if the block has the ExplodeBehaviour in collisionBehaviours
        var collisionBehaviourType = GetBehaviourTypesFromField(block, collisionBehavioursField);

        CollectionAssert.AreEquivalent(
            new[] { typeof(ExplodeBehaviour) },
            collisionBehaviourType
        );

        yield return null; // Wait a frame for the movement
    }

    [UnityTest]
    public IEnumerator SpawnBlueBlockBehaviour_ShouldHaveMove()
    {
        var block = blockSpawner.SpawnBlock(
            new BlockData(
                null,
                BlockColour.Blue,
                new int2(0, 0)
            )
        );
        yield return null; // Wait for Start/Awake

        Assert.IsNotNull(block, "Block was not spawned successfully.");

        // Check if the block has the Move in updateBehaviours
        var updateBehaviourType = GetBehaviourTypesFromField(block, updateBehavioursField);

        CollectionAssert.AreEquivalent(
            new[] { typeof(MoveBehaviour) },
            updateBehaviourType
        );

        yield return null; // Wait a frame for the movement
    }

    [UnityTest]
    public IEnumerator SpawnPurpleBlockBehaviour_ShouldHaveMoveAndExplode()
    {
        var block = blockSpawner.SpawnBlock(
            new BlockData(
                null,
                BlockColour.Purple,
                new int2(0, 0)
            )
        );
        yield return null; // Wait for Start/Awake

        Assert.IsNotNull(block, "Block was not spawned successfully.");

        // Check if the block has the Move in updateBehaviours
        var updateBehaviourType = GetBehaviourTypesFromField(block, updateBehavioursField);

        CollectionAssert.AreEquivalent(
            new[] { typeof(MoveBehaviour) },
            updateBehaviourType
        );

        // Check if the block has the ExplodeBehaviour in collisionBehaviours
        var collisionBehaviourType = GetBehaviourTypesFromField(block, collisionBehavioursField);

        CollectionAssert.AreEquivalent(
            new[] { typeof(ExplodeBehaviour) },
            collisionBehaviourType
        );

        yield return null; // Wait a frame for the movement
    }


    private Block SpawnEmptyBlock(int2 position)
    {
        return blockSpawner.SpawnBlock(
            new BlockData(
                null,
                BlockColour.Empty,
                position
            )
        );
    }


    // Extracts the types of behaviours from the block instance for assertions

    private System.Type[] GetBlockBehavioursTypes(Block block)
    {
        var updateTypes = GetBehaviourTypesFromField(block, "_updateBehaviours");
        var collisionTypes = GetBehaviourTypesFromField(block, "_collisionBehaviours");

        // Combine and return
        return updateTypes.Concat(collisionTypes).Distinct().ToArray();
    }
    
    private System.Type[] GetBehaviourTypesFromField(Block block, string fieldName)
    {
        var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;

        var fieldInfo = typeof(Block).GetField(fieldName, bindingFlags);
        if (fieldInfo == null) return Array.Empty<System.Type>();

        var behaviours = fieldInfo.GetValue(block) as System.Collections.IEnumerable;
        if (behaviours == null) return Array.Empty<System.Type>();

        return behaviours.Cast<IBlockBehaviour>().Select(b => b.GetType()).ToArray();
    }
}
*/