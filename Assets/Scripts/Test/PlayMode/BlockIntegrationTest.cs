using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Assets.Scripts.Blocks;
using Unity.Mathematics;
using Assets.Scripts.Blocks.Domain;
using Assets.Scripts.SharedKernel;

public class BlockIntegrationTest
{
    private GameObject blockSpawnerObject;
    private BlockSpawner blockSpawner;
    [SerializeField] public GameObject blockPrefab;

    [SetUp]
    public void SetUp()
    {
        // Create a new GameObject and add BlockSpawner component
        blockSpawnerObject = new GameObject("BlockSpawner");
        blockSpawner = blockSpawnerObject.AddComponent<BlockSpawner>();
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(blockSpawnerObject);
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
            Object.Destroy(block);
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
    public IEnumerator SpawnedBlockColours_ShouldBeRenderedCorrcetly()
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
    public IEnumerator SpawnRedBlockBehaviour_ShouldExplode()
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

        // Move the block to a new position
        block.ExecuteBehaviours();

        //TODO check explosion after it is implemented
        
        yield return null; // Wait a frame for the movement
    }

    [UnityTest]
    public IEnumerator SpawnBlueBlockBehaviour_ShouldMove()
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

        // Move the block to a new position
        block.ExecuteBehaviours();

        //TODO check movement after it is implemented
        
        yield return null; // Wait a frame for the movement
    }

        [UnityTest]
    public IEnumerator SpawnPurpleBlockBehaviour_ShouldMoveAndExplode()
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

        // Move the block to a new position
        block.ExecuteBehaviours();

        //TODO check movement after it is implemented
        
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
}
