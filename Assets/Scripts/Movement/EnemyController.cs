using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D.Movement
{
    public static class EnemyFactory
    {
        public static EnemyController ReturnEnemyController()
        {
            return new EnemyController();
        }
    }
    public interface IEnemyController
    {
        void InitializeEnemyController(EnemyMovement enemyMovement);
        void GotoPointB();
        void GotoPointA();
        void FollowPlayer();
        void ShootBullet();
    }
    public class EnemyController:IEnemyController
    {
        EnemyMovement enemyMovement;
        Vector3 leftScale = new Vector3(-1, 1, 1);
        Vector3 rightScale = Vector3.one;
        public EnemyController()
        {

        }
        public void InitializeEnemyController(EnemyMovement enemyMovement)
        {
            this.enemyMovement = enemyMovement;
        }
        public void GotoPointB()
        {
            if (enemyMovement.pointBDistance < .5f)
            {
                enemyMovement.reachedAtB = true;
                enemyMovement.reachedAtA = false;
            }
            enemyMovement.transform.localScale = leftScale;
            enemyMovement.transform.position = Vector3.MoveTowards(enemyMovement.transform.position, enemyMovement.pointB.position, enemyMovement.speed * Time.deltaTime);
        }

        public void GotoPointA()
        {
            if (enemyMovement.pointADistance < .5f)
            {
                enemyMovement.reachedAtA = true;
                enemyMovement.reachedAtB = false;
            }
            enemyMovement.transform.localScale = rightScale;
            enemyMovement.transform.position = Vector3.MoveTowards(enemyMovement.transform.position, enemyMovement.pointA.position, enemyMovement.speed * Time.deltaTime);
        }
        public void FollowPlayer()
        {
            enemyMovement.transform.localScale = leftScale;
            enemyMovement.transform.position = Vector3.MoveTowards(enemyMovement.transform.position, enemyMovement.pointB.position, Time.deltaTime * enemyMovement.speed);
        }
        public void ShootBullet()
        {
            Bullet bullet = enemyMovement.bulletPool.GetAvailableBullet();
            bullet.isShootByEnemy = true;
            bullet.FireBullet(Vector3.down, 5, enemyMovement.shootTransform.position);
        }
    }
}