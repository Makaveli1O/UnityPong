using UnityEngine;

public class PlayerParticleController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _upwardsParticles;
    [SerializeField] private ParticleSystem _downwardsParticles;

    public void StartUpwardThrust()
    {
        _upwardsParticles.Play();
        _downwardsParticles.Stop();
    }

    public void StartDownwardThrust()
    {
        _upwardsParticles.Stop();
        _downwardsParticles.Play();
    }

    public void StopBothThrusts()
    {
        _downwardsParticles.Stop();
        _upwardsParticles.Stop();
    }
    
}