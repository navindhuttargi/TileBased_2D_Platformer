using Platformer2D;
using UnityEngine;

namespace Platformer2D.Services
{
    public class ScoreHandler : IScoreHandler
    {
        public ScoreHandler()
        {
            GameManager.Instance.restartGame += ResetScore;
        }

        private void ResetScore()
        {
            coinsCollected = 0;
            score = 0;
        }
        public void Initialize(int total)
        {
            totalCoins = total;
        }
        ~ScoreHandler()
        {
            GameManager.Instance.restartGame -= ResetScore;
        }
        [SerializeField] int totalCoins;
        [SerializeField] int coinsCollected;
        [SerializeField] int score;
        public void CollectCoin()
        {
            coinsCollected += 1;
            GameManager.Instance.UpdateScore();
            if (CheckForGameWin()) GameManager.Instance.GameStatus(true);
            //raise update score event
        }
        public int TotalCoinsCollected()
        {
            return coinsCollected;
        }
        public bool CheckForGameWin()
        {
            return totalCoins == coinsCollected;
        }
    }
}