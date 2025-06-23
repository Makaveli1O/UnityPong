
using Assets.Scripts.Blocks;
using UnityEngine;

public class ExplodeBehaviour : MonoBehaviour, ICollisionBehaviour
{
    public void Execute(Block context)
    {
        Debug.Log("Executing ExplodeBehaviour on block.");
    }
}