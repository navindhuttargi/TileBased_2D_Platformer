using Platformer2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D.Services
{
    public class PlayerSpawner : IPlayerSpawner
    {
        public GameObject playerRefGO { get; private set; }
        GameObject playerPrefab;
        public PlayerSpawner()
        {
            GameManager.Instance.restartGame += ResetPlayer;
        }
        ~PlayerSpawner()
        {
            GameManager.Instance.restartGame -= ResetPlayer;
        }
        public void InitializePlayerSpawner(GameObject prefab)
        {
            playerPrefab = prefab;
        }
        public void SpwanPlayer()
        {
            playerRefGO = Object.Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        }
        void ResetPlayer()
        {
            Object.Destroy(playerRefGO);
        }
    }
}