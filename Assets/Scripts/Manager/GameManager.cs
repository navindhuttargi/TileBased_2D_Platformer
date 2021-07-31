using Platformer2D.Movement;
using Platformer2D.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{

    public class GameManager : MonoBehaviour
    {
        public Transform interactablesParent, enemyParent;
        public Config config;

        public System.Action restartGame;
        public System.Action scoreUpdate;
        public System.Action<bool> gameStatus;
        private static GameManager _instance;
        public StateController controller;
        public UIManager uIManager;
        public CameraFollow cameraFollow;
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<GameManager>();
                return _instance;
            }
        }
        private void Awake()
        {
            _instance=this;
            controller = new StateController(this, StateController.GameStates.initialize);
        }
        public void GameReady()
        {
        }
        public void RestartGame()
        {
            restartGame?.Invoke();
        }
        public void GameStatus(bool isWon)
        {
            gameStatus?.Invoke(isWon);
            RestartGame();
        }
        public void UpdateScore()
        {
            scoreUpdate?.Invoke();
        }
    }
}