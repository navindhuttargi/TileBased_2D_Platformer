using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : MonoBehaviour
{
    [SerializeField]
    Transform pointA, pointB,followRigt,followLeft;
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    Transform player;
    [SerializeField]
    float xOffset = 3;
    bool reachedAtA, reachedAtB;
    float pointADistance = 0;
    float pointBDistance = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        if (Camera.main.transform.position.x + xOffset < player.transform.position.x)
        {
            FollowPlayer();
        }
        else
        {
            pointADistance = Vector3.Distance(transform.position, pointA.position);
            pointBDistance = Vector3.Distance(transform.position, pointB.position);
            if (!reachedAtA)
            {
                GotoPointA();
            }
            else if (!reachedAtB)
            {
                GotoPointB();
            }
        }
    }

    private void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, pointB.position, Time.deltaTime*speed);
    }

    private void GotoPointB()
    {
        if (pointBDistance < .5f)
        {
            reachedAtB = true;
            reachedAtA = false;
        }
        transform.position = Vector3.MoveTowards(transform.position, pointB.position,speed* Time.deltaTime);
    }

    private void GotoPointA()
    {
        if (pointADistance < .5f)
        {
            reachedAtA = true;
            reachedAtB = false; 
        }
        transform.position = Vector3.MoveTowards(transform.position, pointA.position,speed*Time.deltaTime);
    }
}
