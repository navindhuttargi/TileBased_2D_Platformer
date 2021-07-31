using Platformer2D;
using Platformer2D.Movement;
using UnityEngine;

namespace Platformer2D.Interactables
{
    public class WalkAndDiveItem : BaseItem
    {
        protected override void Start()
        {
            base.Start();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            PickUpWalkPowerUp(collision);
        }
        private void PickUpWalkPowerUp(Collider2D collision)
        {
            PlayerMovement player = GetPlayer(collision);
            if (player)
            {
                player.canWalkonFireWater = true;
                gameObject.SetActive(false);
            }
        }
    }
}