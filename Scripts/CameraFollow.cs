using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform followObject;
    [SerializeField]
    Cinemachine.CinemachineVirtualCamera cinemachine;
    void Start()
    {
        cinemachine.Follow = followObject;
    }
}
