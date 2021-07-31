using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D.Movement
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField]
        private Transform followObject;
        [SerializeField]
        Cinemachine.CinemachineVirtualCamera cinemachine;

        public void SetFollowTransform(Transform player)
        {
            followObject = player;
            cinemachine.Follow = followObject;
            cinemachine.gameObject.SetActive(true);
        }
    }
}