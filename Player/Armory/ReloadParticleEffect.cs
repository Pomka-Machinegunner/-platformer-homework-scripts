using UnityEngine;

public class ReloadParticleEffect : MonoBehaviour
{
    public ParticleSystem _reloadParticles;

    public void Reloaded()
    {
        _reloadParticles.Play();
    }
}
