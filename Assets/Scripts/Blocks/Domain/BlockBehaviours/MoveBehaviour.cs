
using Assets.Scripts.Blocks;
using UnityEngine;

public class MoveBehaviour : MonoBehaviour, IBlockBehaviour
{
    public void Execute(Block context)
    {
        Debug.Log("Execuing MoveBehaviour");
    }
}