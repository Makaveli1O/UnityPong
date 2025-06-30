using UnityEngine;

namespace Assets.Scripts.Sound
{
    public class SoundPlayer : MonoBehaviour, ISoundPlayer
    {
        [SerializeField] private AudioSource _sfxSource ;
        [SerializeField] private AudioSource _musicSource;

        public void PlaySfx(AudioClip clip)
        {
            if (clip != null)
                _sfxSource.PlayOneShot(clip);
        }

        public void PlayMusic(AudioClip clip, bool loop = true)
        {
            if (_musicSource.clip == clip && _musicSource.isPlaying)
                return;

            _musicSource.clip = clip;
            _musicSource.loop = loop;
            _musicSource.Play();
        }

        public void StopMusic()
        {
            _musicSource.Stop();
        }
    }
}