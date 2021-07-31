using Platformer2D;
using Platformer2D.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagables : MonoBehaviour
{
    private void Start()
    {
        //GetComponent<Collider2D>().isTrigger = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        PlayerMovement player = collision.transform.GetComponent<PlayerMovement>();
        if (player && !player.canWalkonFireWater)
        {
            player.DeathAnimation();
        }
    }
}
