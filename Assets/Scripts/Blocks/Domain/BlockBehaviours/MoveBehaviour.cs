
using Assets.Scripts.Blocks;
using UnityEngine;

public class MoveBehaviour : MonoBehaviour, IBlockBehaviour
{
    public void Execute(Block context)
    {
        // TODO: Implement the logic for moving the block.
        Debug.Log("Executing MoveBehaviour on block.");
    }
}