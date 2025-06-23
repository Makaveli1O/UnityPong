using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Blocks.Domain;
using UnityEngine;

namespace Assets.Scripts.Blocks
{
    public class Block : MonoBehaviour
    {
        private BlockData _blockData;
        private SpriteRenderer _spriteRenderer;
        private List<IBlockBehaviour> _behaviours;

        public void ExecuteBehaviours()
        {
            foreach (var behaviour in _behaviours)
            {
                behaviour.Execute(this);
            }
        }

        public void Initialize(BlockData blockData)
        {
            _blockData = blockData;
            _spriteRenderer = GetComponent<SpriteRenderer>();

            if (_spriteRenderer == null)
            {
                throw new System.Exception("SpriteRenderer component is missing on the Block GameObject.");
            }

            _behaviours = GetComponents<IBlockBehaviour>().ToList();
            _spriteRenderer.color = BlockColourBehaviourResolver.ToColour(blockData.Colour);
        }

        private void OnCollisionExit2D()
        {
            Destroy(gameObject);
        }
    }
}

