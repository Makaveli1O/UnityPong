
using Assets.Scripts.Blocks;
using UnityEngine;

public class ExplodeBehaviour : MonoBehaviour, IBlockBehaviour
{
    public void Execute(Block context)
    {
        // TODO : Implement the logic for exploding the block.
        Debug.Log("Executing ExplodeBehaviour on block.");
    }
}