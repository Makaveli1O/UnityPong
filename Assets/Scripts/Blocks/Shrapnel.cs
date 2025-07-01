using Assets.Scripts.SharedKernel;
using UnityEngine;

namespace Assets.Scripts.Blocks
{
    public class Shrapnel : MonoBehaviour
    {
        private ISoundPlayer _soundPlayer;
        [SerializeField] private AudioClip _hitClip;
        void Awake()
        {
            _soundPlayer = SimpleServiceLocator.Resolve<ISoundPlayer>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            _soundPlayer.PlaySfx(_hitClip);
        }
    }
}