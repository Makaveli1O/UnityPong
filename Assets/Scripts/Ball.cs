using UnityEngine;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;

namespace DefaultNamespace
{
    public class Ball : MonoBehaviour
    {
        private float initialSpeed = 200f;
        private float maxSpeed = 1000f;
        private float speedIncreaseFactor = 1.5f;

        private Rigidbody2D _rb;

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
                Random.Range(-1.0f, 0.5f) :
                Random.Range(0.5f, 1.0f);

            // Set initial velocity
            Vector2 direction = new Vector2(x, y).normalized;
            _rb.AddForce(direction * initialSpeed);
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (_rb.linearVelocity.magnitude >= maxSpeed)
                {
                    Debug.Log("Max speed reached, no further increase.");
                    return;
                }
                _rb.AddForce(collision.relativeVelocity.normalized * speedIncreaseFactor);
            }
        }
    }
}