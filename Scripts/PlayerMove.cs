using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove 
{
    Player playerMovement;
    bool m_Grounded;
    public PlayerMove(Player playerMovement)
    {
        this.playerMovement = playerMovement;
    }
    public void UpdateMovenet(float moveInput,bool jump)
    {
        GroundCheck();
        MovePlayer(moveInput);
        if (playerMovement.facingRight == false && playerMovement.moveInput > 0)
            FlipPlayer();
        else if (playerMovement.facingRight == true && playerMovement.moveInput < 0)
            FlipPlayer();
        if (m_Grounded && jump)
        {
            Jump();
        }
    }
    private void Jump()
    {
        playerMovement.rgbody.velocity = Vector2.up * playerMovement.jumpForce;
    }
    void GroundCheck()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(playerMovement.groundTransform.position, playerMovement.checkRaduis,playerMovement.groundMask);
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
}
