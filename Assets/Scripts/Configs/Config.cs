using UnityEditor;
using UnityEngine;
[CreateAssetMenu(fileName = "Config/Level1")]
public class Config : ScriptableObject
{
    public GameObject playerPrefab, enemy1Prefab, enemy2Prefab;
    public Bullet bulletPrefab;
    [ReadOnly]
    public int totalCoins = 24;
    public int bulletLength;
    [Range(1, 2)]
    public int enemyCount = 0;
}
