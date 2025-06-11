using System;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;

namespace DefaultNamespace
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private float initialSpeed = 50f;
        [SerializeField] private float maxSpeed = 10f;
        [SerializeField] private float speed = 200f;

        private Rigidbody2D _rb;
        private Vector2 _lastVelocity;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            LaunchBall();
        }
        
        public void LaunchBall()
        {
            float x = -1f; // always launch to the left
            float y = Random.value < 0.5f ?
                Random.Range(-1.0f,0.5f) :
                Random.Range(0.5f, 1.0f);
            
            // Set initial velocity
            Vector2 direction = new Vector2(x, y).normalized;
            _rb.AddForce(direction * speed);
        }
    }
}