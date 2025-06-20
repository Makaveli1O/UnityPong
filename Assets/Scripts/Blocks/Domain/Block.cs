using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Blocks
{
    public class Block : MonoBehaviour
    {
        public BlockData Data { get; private set; }

        private List<IBlockBehaviour> _behaviours;

        public void Initialize(BlockData data, List<IBlockBehaviour> behaviours)
        {
            Data = data;
            _behaviours = behaviours;
        }

        public void ExecuteBehaviours()
        {
            foreach (var behaviour in _behaviours)
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

