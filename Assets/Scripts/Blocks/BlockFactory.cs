using System;
using System.Collections.Generic;
using Assets.Scripts.Blocks;
using Assets.Scripts.SharedKernel;
using UnityEngine;

public class BlockFactory : MonoBehaviour, IBlockFactory
{
    [SerializeField] private GameObject _blockPrefab;
    [SerializeField] private IBlockBehaviourResolver _resolver;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        _resolver = SimpleServiceLocator.Resolve<IBlockBehaviourResolver>();
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        if (_blockPrefab == null)
        {
            throw new Exception("Block prefab is not assigned in the inspector.");
        }

        if (_resolver == null)
        {
            throw new Exception("BlockFactory not initialized with behaviour resolver.");
        }
    }

    public Block SpawnBlock(BlockData blockData, Transform parent)
    {
        if (_blockPrefab == null) throw new Exception("Block prefab is not assigned.");
        if (_resolver == null) throw new Exception("BlockFactory not initialized with behaviour resolver.");

        Vector2 pos = PositionConvertor2D.ToVector2(blockData.Position);
        GameObject go = Instantiate(_blockPrefab, pos, Quaternion.identity, parent);

        var block = go.GetComponent<Block>();
        if (block == null) throw new Exception("Block component not found on the prefab.");

        var behaviourTypes = _resolver.Resolve(blockData.Colour);
        var behaviours = new List<IBlockBehaviour>();

        foreach (var type in behaviourTypes)
        {
            var behaviour = (IBlockBehaviour)go.AddComponent(type);
            behaviours.Add(behaviour);
        }

        return go.GetComponent<Block>();
    }
}
