using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CinamaMachineController : MonoBehaviour
{
    private CinemachineVirtualCamera camera;

    public static CinamaMachineController Instance
    {
        get;
        private set;
    }
    private float timerSHaker;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            camera = GetComponent<CinemachineVirtualCamera>();
        }
       
      
      
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
