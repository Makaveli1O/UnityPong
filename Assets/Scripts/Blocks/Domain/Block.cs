using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Blocks
{
    public class Block : MonoBehaviour
    {
        public void ExecuteBehaviours()
        {
            foreach (var behaviour in GetComponents<IBlockBehaviour>())
            {
                behaviour.Execute(this);
            }
        }

        private void OnCollisionExit2D()
        {
            Destroy(gameObject);
        }
    }
}

