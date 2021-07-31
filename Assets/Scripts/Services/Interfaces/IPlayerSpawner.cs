using UnityEngine;

public interface IPlayerSpawner
{
    void InitializePlayerSpawner(GameObject prefab);
    void SpwanPlayer();
    GameObject playerRefGO { get; }
}
