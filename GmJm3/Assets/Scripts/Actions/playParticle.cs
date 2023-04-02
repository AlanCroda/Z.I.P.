using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleVFX;

    public void PlayParticleVFX()
    {
        particleVFX.Play();
    }
}
