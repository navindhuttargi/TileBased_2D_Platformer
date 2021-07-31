using Platformer2D.Movement;
using Platformer2D.Services;
using UnityEngine;

namespace Platformer2D.Interactables
{
    public class CoinItem : BaseItem
    {
        protected override void Start()
        {
            base.Start();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            PickUpCoin(collision);
        }
        void PickUpCoin(Collider2D collision)
        {
            PlayerMovement player = GetPlayer(collision);
            if (player)
            {
                ServiceLocator.GetService<IScoreHandler>().CollectCoin();
                if (ServiceLocator.GetService<IScoreHandler>().CheckForGameWin())
                {
                    Debug.Log("GameOver All coins are collected");
                    GameManager.Instance.GameStatus(true);
                }
                gameObject.SetActive(false);
            }
        }
    }
}