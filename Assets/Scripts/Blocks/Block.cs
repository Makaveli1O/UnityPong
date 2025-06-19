using UnityEngine;

namespace Assets.Scripts.Blocks
{
    public class Block : MonoBehaviour
    {
        private void OnCollisionExit2D()
        {
            Destroy(gameObject);
        }
    }
}

