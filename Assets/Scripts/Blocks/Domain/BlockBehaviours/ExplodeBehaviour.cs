
using Assets.Scripts.Blocks;
using UnityEngine;

public class ExplodeBehaviour : MonoBehaviour, IBlockBehaviour
{
    public void Execute(Block context)
    {
        Debug.Log("Execuing ExplodeBehaviour");
    }
}