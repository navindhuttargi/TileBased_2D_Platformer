using Platformer2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D.Services
{
    public class BulletPool : IBulletPool
    {
        Bullet bulletPrefab;
        List<Bullet> bullets = new List<Bullet>();
        int bulletLength = 15;
        GameObject bulletPoolParent;

        public BulletPool()
        {
            GameManager.Instance.restartGame += ResetPool;
        }
        public void InitializePool(Bullet prefab, int length)
        {
            bulletPrefab = prefab;
            bulletLength = length;
            bulletPoolParent = new GameObject();
            for (int i = 0; i < bulletLength; i++)
            {
                AddBullet(bulletPoolParent);
            }
        }

        private void AddBullet(GameObject bulletPoolParent)
        {
            bullets.Add(Object.Instantiate(bulletPrefab, bulletPoolParent.transform));
            bullets[bullets.Count - 1].gameObject.SetActive(false);
        }

        public Bullet GetAvailableBullet()
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].gameObject.activeInHierarchy)
                {
                    return bullets[i];
                }
                if (i == bullets.Count - 1)
                {
                    AddBullet(bulletPoolParent);
                    return bullets[bullets.Count - 1];
                }
            }
            return null;
        }
        void ResetPool()
        {
            for (int i = 0; i < bulletLength; i++)
            {
                bullets[i].isShootByEnemy = false;
                bullets[i].gameObject.SetActive(false);
            }
        }
    }
}