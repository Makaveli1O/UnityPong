using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Blocks
{
    public class Block : MonoBehaviour
    {
        [SerializeField] private AudioClip _destroyClip;
        [SerializeField] public GameObject shrapnelPrefab;
        public BlockData Data { get; private set; }
        private SpriteRenderer _spriteRenderer;
        private readonly List<IUpdateBehaviour> _updateBehaviours = new();
        private readonly List<ICollisionBehaviour> _collisionBehaviours = new();

        public void SetData(BlockData data)
        {
            Data = data;
        }

        public void AddUpdateBehaviour(IUpdateBehaviour behaviour)
        {
            _updateBehaviours.Add(behaviour);
        }

        public void AddCollisionBehaviour(ICollisionBehaviour behaviour)
        {
            _collisionBehaviours.Add(behaviour);
        }

        public void SetColour(Color color)
        {
            if (_spriteRenderer == null)
                _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.color = color;
        }

        private void Update()
        {
            foreach (var behaviour in _updateBehaviours)
                behaviour.OnUpdateExecute(this);
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            foreach (var behaviour in _collisionBehaviours)
                behaviour.OnCollisionExecute(this, other);
        }
    }


}

