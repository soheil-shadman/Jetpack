using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CMShake : MonoBehaviour
{
    private CinemachineVirtualCamera camera;

    public static CMShake Instance
    {
        get;
        private set;
    }
    private float timerSHaker;

    private void Awake()
    {
        Instance = this;
        camera = GetComponent<CinemachineVirtualCamera>();
    }

    public void Update()
    {
        if (timerSHaker > 0)
        {
            timerSHaker -= Time.deltaTime;
            if (timerSHaker <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                    camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
            }
        }
    }

    public void Shacker(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        timerSHaker=time;
        
    }
}
