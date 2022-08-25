using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    CinemachineVirtualCamera virtualCamera;
    float shakeTimer;

    // Start is called before the first frame update
    void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }


    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin perlin =
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        perlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= float.Epsilon)
            {
                CinemachineBasicMultiChannelPerlin perlin =
                    virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                perlin.m_AmplitudeGain = 0f;

            }
        }
      
    }
}
