using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Blocks
{
    public class Block : MonoBehaviour
    {
        private BlockData _blockData;
        private SpriteRenderer _spriteRenderer;
        // Behaviour triggers
        private List<IUpdateBehaviour> _updateBehaviours;
        private List<ICollisionBehaviour> _collisionBehaviours;

        public void ExecuteUpdateBehaviours()
        {
            foreach (var behaviour in _updateBehaviours)
            {
                behaviour.Execute(this);
            }
        }

        public void ExecuteCollisionBehaviours()
        {
            foreach (var behaviour in _collisionBehaviours)
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
            
            _updateBehaviours = GetComponents<IUpdateBehaviour>().ToList();
            _collisionBehaviours = GetComponents<ICollisionBehaviour>().ToList();

            _spriteRenderer.color = BlockColourBehaviourResolver.ToColour(blockData.Colour);
        }

        private void Update()
        {
            ExecuteUpdateBehaviours();
        }

        private void OnCollisionExit2D()
        {
            ExecuteCollisionBehaviours();
        }
    }
}

