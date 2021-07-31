using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCrouchMovement : MonoBehaviour
{
    [SerializeField]
    Transform pointA, pointB;
    [SerializeField]
    float speed = 2, aDistance = 0, bDistance = 0;
    public enum EnemyMoveState
    {
        idle=0,
        pointA,
        pointB,
        pointAEdge,
        pointBEdge
    }
    [SerializeField]
    EnemyMoveState enemyMoveState;
    [SerializeField]
    float waitDuration = .1f;
    float waitTime = 0;
    Quaternion downRotation = Quaternion.Euler(Vector3.forward * 180);
    Quaternion idleRotation = Quaternion.Euler(Vector3.zero);
    private void Start()
    {
        enemyMoveState = EnemyMoveState.pointA;
        waitTime = waitDuration;
    }
    void Update()
    {
        switch (enemyMoveState)
        {
            case EnemyMoveState.idle:
                break;
            case EnemyMoveState.pointA:
                GotoPointA();
                break;
            case EnemyMoveState.pointAEdge:
                GotoPointAEdge();
                break;
            case EnemyMoveState.pointB:
                GotoPointB();
                break;
            case EnemyMoveState.pointBEdge:
                GotoPointBEdge();
                break;
            default:
                break;
        }
    }

    private void GotoPointA()
    {
        aDistance = Vector3.Distance(transform.position, pointA.position);
        if (aDistance <= .1f)
        {
            transform.position = pointA.position;
            enemyMoveState = EnemyMoveState.pointAEdge;
        }
        transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
    }
    private void GotoPointAEdge()
    {
        if (transform.rotation!= downRotation)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation,downRotation,Time.deltaTime);
            float angle = Vector3.Angle(transform.rotation.eulerAngles, downRotation.eulerAngles);
            Debug.Log(angle);
            if (angle<1)
                enemyMoveState = EnemyMoveState.pointB;
        }
    }
    private void GotoPointB()
    {
        bDistance = Vector3.Distance(transform.position, pointB.position);
        if (bDistance <= .1f)
        {
            enemyMoveState = EnemyMoveState.pointBEdge;
            transform.position = pointB.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
    }
    private void GotoPointBEdge()
    {
        if (transform.rotation!= idleRotation)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation,idleRotation,Time.deltaTime);
            float angle = Vector3.Angle(transform.rotation.eulerAngles, idleRotation.eulerAngles);
            Debug.Log(angle);
            if (angle < 1)
                enemyMoveState = EnemyMoveState.pointA;
        }
    }
}
