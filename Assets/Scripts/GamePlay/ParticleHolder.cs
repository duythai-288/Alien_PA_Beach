using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHolder : MonoBehaviour
{
    public ParticleSystem[] effects;
    ParticlePool particlePool;
    void Start()
    {
        // 0 = Normal crate
        // 1 = TNT crate
        particlePool = new ParticlePool(effects[0], 5);
    }

    public void PlayParticle(Vector3 particlePos)
    {
        ParticleSystem particleToPlay = particlePool.GetAvailabeParticle();

        if (particleToPlay != null)
        {
            if (particleToPlay.isPlaying)
                particleToPlay.Stop();

            particleToPlay.transform.position = particlePos;
            particleToPlay.Play();
        }

    }
}
