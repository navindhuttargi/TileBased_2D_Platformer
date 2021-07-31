using Platformer2D.Movement;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemySpawner
{
    List<EnemyMovement> enemies { get; }
    void InitializeEnemySpawner(GameObject prefab, Transform transform,int enemyCount, GameObject prefab2 = null);
    void SpawnEnemy();
}
