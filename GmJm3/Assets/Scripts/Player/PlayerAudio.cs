using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    AudioSource audioSource;
    float _timeSinceLastStepPlayed = 0.1f;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void sfXWalk(AudioClip clip)
    {
        _timeSinceLastStepPlayed += Time.deltaTime;
        if (_timeSinceLastStepPlayed > 1)
        {
            _timeSinceLastStepPlayed = 0;
            audioSource.loop = true;
            audioSource.pitch = Random.Range(1.0f, 0.98f);
            audioSource.PlayOneShot(clip);
        }
    }

    public void sfxJump(AudioClip clip)
    {
        audioSource.loop = false;
        audioSource.pitch = Random.Range(1.0f, 0.98f);
        audioSource.PlayOneShot(clip);
    }

    public void sfxWallSlide(AudioClip clip)
    {
        _timeSinceLastStepPlayed += Time.deltaTime;
        if (_timeSinceLastStepPlayed > clip.length)
        {
            _timeSinceLastStepPlayed = 0;
            audioSource.loop = true;
            audioSource.pitch = Random.Range(1.0f, 0.98f);
            audioSource.PlayOneShot(clip);
        }
    }

    public void stopAudio()
    {
        audioSource.Stop();
    }
}
