using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class screenShake : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;
    private CinemachineBasicMultiChannelPerlin noise;

    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        noise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void ShakeScreen(float duration, float intensity)
    {
        StartCoroutine(ShakeScreenCoroutine(duration, intensity));
    }

    private IEnumerator ShakeScreenCoroutine(float duration, float intensity)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            float t = elapsed / duration;
            float damping = Mathf.Lerp(intensity, 0f, t);
            noise.m_AmplitudeGain = damping;
            noise.m_FrequencyGain = damping * 10f;
            elapsed += Time.deltaTime;
            yield return null;
        }
        noise.m_AmplitudeGain = 0f;
        noise.m_FrequencyGain = 0f;
    }
}

