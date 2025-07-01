using UnityEngine;

namespace Assets.Scripts.SharedKernel
{
    public interface ISoundPlayer
    {
        void PlaySfx(AudioClip clip);
        void PlayMusic(AudioClip clip, bool loop = true);
        void StopMusic();
    }
}