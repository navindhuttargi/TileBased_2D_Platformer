using Platformer2D;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D.Movement
{
    public class EnemyCrouchMovement : BaseEnemy
    {
        [SerializeField]
        List<Transform> paths = new List<Transform>();
        [SerializeField]
        float speed = 5;
        Transform destination;
        int counter = 0;
        float distance = 0;
        Vector3 spawnPosition = new Vector3(5.49f, 0.51f, 5.62f);
        protected override void Start()
        {
            base.Start();
            destination = paths[counter];
            transform.parent.position = spawnPosition;
        }
        private void Update()
        {
            Move();
        }
        void Move()
        {
            distance = GetDistance();
            MoveToDestination();
            SetRotation();

            if (distance < .1f)
            {
                transform.position = destination.position;
                counter += 1;
                if (counter == paths.Count) counter = 0;
                destination = paths[counter];
            }
        }

        private void SetRotation()
        {
            if (counter == 1 || counter == 3 || counter == 5 || counter == 7)
                transform.position = destination.position;

            Vector3 targetVector = destination.position - transform.position;
            targetVector.Normalize();
            float angle = Mathf.Atan2(targetVector.y, targetVector.x) * Mathf.Rad2Deg;
            angle -= 180;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        void MoveToDestination()
        {
            transform.position = Vector3.MoveTowards(transform.position, destination.position, speed * Time.deltaTime);
        }
        float GetDistance()
        {
            return Vector3.Distance(transform.position, destination.position);
        }
    }
}