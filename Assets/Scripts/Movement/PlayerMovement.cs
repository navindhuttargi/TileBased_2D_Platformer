using Platformer2D.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D.Movement
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CapsuleCollider2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [HideInInspector]
        public float speed = 5, jumpForce = 7, moveInput;
        [HideInInspector]
        public Rigidbody2D rgbody;
        [HideInInspector]
        public bool facingRight = true;
        [HideInInspector]
        public bool canShoot = false, canWalkonFireWater = false;

        public float checkRaduis=.1f;

        public Transform shootTransform;
        public Transform groundTransform;
        public LayerMask groundMask;

        IPlayerController playerMove;
        IBulletPool bulletPool;
        Animator animator;
        float bulletShootTimer = 1;
        float timeSinceLastBulletShoot = 0;
        bool jump = false;
        bool dead = false;

        void Start()
        {
            rgbody = GetComponent<Rigidbody2D>();
            playerMove = ServiceLocator.GetService<IPlayerController>();
            playerMove.InitializePlayerController(this);
            animator = GetComponent<Animator>();
            bulletPool = ServiceLocator.GetService<IBulletPool>();
            dead = false;
        }

        void Update()
        {
            if (dead)
                return;
            GetInput();
        }

        private void GetInput()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump = true;
                animator.SetBool("IsJumping", true);
            }

            moveInput = Input.GetAxisRaw("Horizontal");
            animator.SetFloat("Speed", Mathf.Abs(moveInput));
            FireBullet();
        }
        public void DeathAnimation()
        {
            animator.SetTrigger("die");
            dead = true;
            StartCoroutine(Wait());
        }
        IEnumerator Wait()
        {
            float timer = .5f;
            while (timer > 0)
            {
                timer -= Time.deltaTime;
                yield return null;
            }
            GameManager.Instance.GameStatus(false);
        }
        public void OnDeath()
        {
            GameManager.Instance.GameStatus(false);
        }
        private void FireBullet()
        {
            if (!canShoot)
                return;

            if (timeSinceLastBulletShoot >= bulletShootTimer)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    timeSinceLastBulletShoot = 0;
                    if (facingRight)
                        playerMove.BulletFire(Vector3.right, speed * 2, shootTransform.position, bulletPool.GetAvailableBullet());
                    else
                        playerMove.BulletFire(Vector3.left, speed * 2, shootTransform.position, bulletPool.GetAvailableBullet());
                }
            }
            else
            {
                timeSinceLastBulletShoot += Time.deltaTime;
            }
        }

        public void OnLanding()
        {
            animator.SetBool("IsJumping", false);
        }
        private void FixedUpdate()
        {
            playerMove.UpdateMovenet(moveInput, jump);
            if (jump) jump = false;
        }
    }
}