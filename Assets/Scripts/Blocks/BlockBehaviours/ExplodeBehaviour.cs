
using UnityEngine;
namespace Assets.Scripts.Blocks
{
    public class ExplodeBehaviour : MonoBehaviour, ICollisionBehaviour
    {
        public void Execute(Block context)
        {
            Debug.Log("Executing ExplodeBehaviour on block.");
        }
    }
}