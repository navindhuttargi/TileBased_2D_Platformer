using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D.Movement
{
    public abstract class BaseEnemy : MonoBehaviour
    {
        Animator animator;
        protected bool isPlayerDead = false;
        protected bool isDead;
        protected virtual void Start()
        {
            animator = GetComponent<Animator>();
            isPlayerDead = false;
            isDead = false;
        }
        protected virtual void OnCollisionEnter2D(Collision2D collision)
        {
            PlayerMovement player = collision.transform.GetComponent<PlayerMovement>();
            if (player)
            {
                player.DeathAnimation();
                isPlayerDead = true;
            }
        }
        public void DeathAnimation()
        {
            isDead = true;
            animator.SetTrigger("die");
        }
        public void Deactivate()
        {
            gameObject.SetActive(false);
        }
        public virtual void Configure()
        {

        }
    }
}