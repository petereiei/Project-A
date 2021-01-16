using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public CameraCinemachine cameraCinemachine;

    public void Init(Character character)
    {
        if (cameraCinemachine == null)
            cameraCinemachine = GameObject.Find("CameraCinemachine").GetComponent<CameraCinemachine>();
        else
            Debug.Log("not cameraCinemachine null");

        cameraCinemachine.cinemachineFreeLook.Follow = character.transform;
        cameraCinemachine.cinemachineFreeLook.LookAt = character.transform;
    }
}
