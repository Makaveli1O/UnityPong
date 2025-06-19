using System;
using Assets.Scripts.Blocks;
using Assets.Scripts.SharedKernel;
using UnityEngine;

public class BlockFactory : MonoBehaviour, IBlockFactory
{
    [SerializeField] private GameObject _blockPrefab;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        if (_blockPrefab == null)
        {
            // Throw exception if block prefab is not assigned
            throw new Exception("Block prefab is not assigned in the BlockSpawner.");
        }
    }
    public Block SpawnBlock(BlockData blockData, Transform parent)
    {
        if (_blockPrefab == null) throw new Exception("Block prefab is not assigned.");
        Vector2 pos = PositionConvertor2D.ToVector2(blockData.Position);
        GameObject go = Instantiate(_blockPrefab, pos, Quaternion.identity, parent);
        return go.GetComponent<Block>();
    }
}
