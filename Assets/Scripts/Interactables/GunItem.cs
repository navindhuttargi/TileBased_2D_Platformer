using Platformer2D.Movement;
using UnityEngine;

namespace Platformer2D.Interactables
{
    public class GunItem : BaseItem
    {
        protected override void Start()
        {
            base.Start();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            PickUpGun(collision);
        }
        private void PickUpGun(Collider2D collision)
        {
            PlayerMovement player = GetPlayer(collision);
            if (player)
            {
                player.canShoot = true;
                gameObject.SetActive(false);
            }
        }
    }
}