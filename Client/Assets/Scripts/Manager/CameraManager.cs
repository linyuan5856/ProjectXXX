using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    //public CinemachineBrain cinemachineBrain;
    public CinemachineImpulseSource cinemachineImpulseSource;
    public SignalSourceAsset[] RawSignal_sword;



    public void ShakeScreen(int a)
    {
        Debug.Log("进入震动");
        cinemachineImpulseSource.m_ImpulseDefinition.m_RawSignal = RawSignal_sword[a];
        cinemachineImpulseSource.GenerateImpulse();
    }

}

