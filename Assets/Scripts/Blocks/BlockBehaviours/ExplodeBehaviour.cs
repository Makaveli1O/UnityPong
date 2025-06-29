using System.Collections;
using UnityEngine;
namespace Assets.Scripts.Blocks
{
    public class ExplodeBehaviour : MonoBehaviour, ICollisionBehaviour
    {
        private const int _shrapnelCount = 5;
        private const int _delaySeconds = 2;
        private float _spreadForce = 5f;

        public void OnCollisionExecute(Block context, Collision2D collision)
        {
            Explode(context);
        }

        public void Explode(Block context)
        {
            context.StartCoroutine(ExplosionSequence(context));
        }

        private IEnumerator ExplosionSequence(Block ctx)
        {
            // Blink Effect
            float elapsed = 0f;
            SpriteRenderer sr = ctx.GetComponent<SpriteRenderer>();
            Color originalColor = sr.color;

            while (elapsed < _delaySeconds)
            {
                sr.color = Color.white;
                yield return new WaitForSeconds(0.1f);
                sr.color = originalColor;
                yield return new WaitForSeconds(0.1f);
                elapsed += 0.2f;
            }
            ExecuteExplosion(ctx);
        }

        private void ExecuteExplosion(Block ctx)
        {
            for (int i = 0; i < _shrapnelCount; i++)
            {
                Vector2 dir = Random.insideUnitCircle.normalized;
                Vector3 spawnPos = ctx.transform.position + (Vector3)(dir * 0.5f);

                GameObject shrapnel = Instantiate(ctx.shrapnelPrefab, spawnPos, Quaternion.identity);
                Rigidbody2D rb = shrapnel.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.mass = 0.1f;
                    rb.AddForce(dir * _spreadForce, ForceMode2D.Impulse);
                }
                Destroy(shrapnel, 2f);
            }

            Destroy(ctx.gameObject);
        }
    }
}