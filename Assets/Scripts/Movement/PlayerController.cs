using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D.Movement
{
    public interface IPlayerController
    {
        void InitializePlayerController(PlayerMovement playerMovement);
        void UpdateMovenet(float moveInput, bool jump);
        void BulletFire(Vector3 direction, float speed, Vector3 position, Bullet bullet);
    }
    public class PlayerController:IPlayerController
    {
        PlayerMovement playerMovement;
        public bool m_Grounded;
        public PlayerController()
        {
            
        }
        public void InitializePlayerController(PlayerMovement playerMovement)
        {
            this.playerMovement = playerMovement;
        }
        public void UpdateMovenet(float moveInput, bool jump)
        {
            GroundCheck();
            MovePlayer(moveInput);
            if (playerMovement.facingRight == false && playerMovement.moveInput > 0) FlipPlayer();
            else if (playerMovement.facingRight == true && playerMovement.moveInput < 0) FlipPlayer();
            if (m_Grounded && jump) Jump();
        }

        private void Jump()
        {
            playerMovement.rgbody.velocity = Vector2.up * playerMovement.jumpForce;
        }
        void GroundCheck()
        {
            bool wasGrounded = m_Grounded;
            m_Grounded = false;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(playerMovement.groundTransform.position, playerMovement.checkRaduis, playerMovement.groundMask);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != playerMovement.gameObject)
                {
                    m_Grounded = true;
                    if (!wasGrounded)
                        playerMovement.OnLanding();
                }
            }
        }
        private bool CheckIsGrounded()
        {
            return Physics2D.OverlapCircle(playerMovement.groundTransform.position, playerMovement.checkRaduis, playerMovement.groundMask);
        }
        void PlayerFly()
        {

        }
        private void FlipPlayer()
        {
            playerMovement.facingRight = !playerMovement.facingRight;
            Vector2 scaler = playerMovement.transform.localScale;
            scaler.x *= -1;
            playerMovement.transform.localScale = scaler;
        }

        private void MovePlayer(float moveInput)
        {
            playerMovement.rgbody.velocity = new Vector2(moveInput * playerMovement.speed, playerMovement.rgbody.velocity.y);
        }

        public void BulletFire(Vector3 direction, float speed, Vector3 position, Bullet bullet)
        {
            bullet.FireBullet(direction, speed, position);
        }
    }
}