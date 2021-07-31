using Platformer2D.Movement;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D.Services
{
    public class EnemySpawner : IEnemySpawner
    {
        GameObject enemy1Prefab;
        GameObject enemy2Prefab;
        GameObject enemy2Ref;
        public List<EnemyMovement> enemies { get; private set; }
        Transform parent;
        int enemyCount = 0;
        public EnemySpawner()
        {
            GameManager.Instance.restartGame += ResetEnemy;
        }
        public void InitializeEnemySpawner(GameObject prefab, Transform transform, int count, GameObject prefab2 = null)
        {
            enemy1Prefab = prefab;
            parent = transform;
            enemyCount = count;
            enemies = new List<EnemyMovement>();
            if (prefab2 != null)
                enemy2Prefab = prefab2;
        }
        public void SpawnEnemy()
        {
            for (int i = 0; i < enemyCount; i++)
            {
                enemies.Add(Object.Instantiate(enemy1Prefab, parent).GetComponent<EnemyMovement>());
                enemies[i].GetComponent<EnemyMovement>().SetPoles(parent.GetChild(0), parent.GetChild(1));
            }
            if (enemies.Count == 2)
            {
                enemies[0].transform.position = parent.GetChild(0).position;
                enemies[0].reachedAtA = false;
                enemies[0].reachedAtB = true;
                enemies[1].reachedAtA = true;
                enemies[1].reachedAtB = false;
                enemies[1].transform.position = parent.GetChild(1).position;
                if (enemy2Prefab != null)
                    enemy2Ref = Object.Instantiate(enemy2Prefab);
            }
            else
            {
                enemies[0].CanFollow();
            }
        }
        ~EnemySpawner()
        {
            GameManager.Instance.restartGame -= ResetEnemy;
        }
        void ResetEnemy()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                Object.Destroy(enemies[i].gameObject);
            }
            enemies.Clear();
            if (enemy2Ref != null)
                Object.Destroy(enemy2Ref);
        }
    }
}