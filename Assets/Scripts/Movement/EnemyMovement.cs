using Platformer2D.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D.Movement
{
    public class EnemyMovement : BaseEnemy
    {
        public Transform pointA, pointB;
        public float speed = 5f;
        public bool reachedAtA, reachedAtB;
        public float pointADistance = 0, pointBDistance = 0;
        public IBulletPool bulletPool;
        public Transform shootTransform;

        [SerializeField]
        Transform player;
        [SerializeField]
        float xOffset = 3;
        [SerializeField]
        bool canFollow;
        [SerializeField]
        float bulletShootDiration = 2, timeSinceLastBulletShoot = 0;
        IEnemyController enemyController;
        Transform cameraTransform;
        // Update is called once per frame
        protected override void Start()
        {
            base.Start();
            enemyController = EnemyFactory.ReturnEnemyController();
            enemyController.InitializeEnemyController(this);
            cameraTransform = Camera.main.transform;
            bulletPool = ServiceLocator.GetService<IBulletPool>();
            cameraTransform = Camera.main.transform;
            player = ServiceLocator.GetService<IPlayerSpawner>().playerRefGO.transform;
        }

        void Update()
        {
            if (isPlayerDead || isDead)
                return;
            Move();

            BulletFire();
        }
        public void CanFollow()
        {
            canFollow = true;
        }
        public void SetPoles(Transform a,Transform b)
        {
            pointA = a;
            pointB = b;
        }
        private void BulletFire()
        {
            if (timeSinceLastBulletShoot >= bulletShootDiration)
            {
                enemyController.ShootBullet();
                timeSinceLastBulletShoot = 0;
            }
            else
            {
                timeSinceLastBulletShoot += Time.deltaTime;
            }
        }

        private void Move()
        {
            if (canFollow)
            {
                if (CheckDistance()) enemyController.FollowPlayer();
                else Platrol();
            }
            else Platrol();
        }

        private void Platrol()
        {
            pointADistance = Vector3.Distance(transform.position, pointA.position);
            pointBDistance = Vector3.Distance(transform.position, pointB.position);
            if (!reachedAtA)
            {
                enemyController.GotoPointA();
            }
            else if (!reachedAtB)
            {
                enemyController.GotoPointB();
            }
        }

        private bool CheckDistance()
        {
            return cameraTransform.position.x + xOffset < player.transform.position.x;
        }
        public override void Configure()
        {
            base.Configure();
        }
        void ConfigureA()
        {

        }
        void ConfigureB()
        {

        }
    }
}