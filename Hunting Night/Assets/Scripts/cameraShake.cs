using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour
{
    public static cameraShake Instance {  get; private set; }

    new CinemachineVirtualCamera camera;
    float shakeTimer;
    void Awake()
    {
        Instance = this;
       camera = GetComponent<CinemachineVirtualCamera>(); 
    }

    public void CameraShake(float intensity,float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
    }
    void Update()
    {
        if(shakeTimer>0)
        {
            shakeTimer -= Time.deltaTime;
        }
        if(shakeTimer <=0f)
        {
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0;
        }
    }
}