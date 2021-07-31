using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D),typeof(CircleCollider2D))]
public class Player : MonoBehaviour
{
    [SerializeField]
    public float speed,jumpForce,moveInput;
    [SerializeField]
    public bool jump = false;
    public Rigidbody2D rgbody;

    public bool facingRight = true;
    [SerializeField]
    public Transform groundTransform;
    [SerializeField]
    public LayerMask groundMask;
    [SerializeField]
    public float checkRaduis;
    PlayerMove playerMove;
    Animator animator;
    void Start()
    {
        rgbody = GetComponent<Rigidbody2D>();
        playerMove = new PlayerMove(this);
        animator = GetComponent<Animator>();
    }

    void Update()
    {
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
    }
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
    private void FixedUpdate()
    {
        playerMove.UpdateMovenet(moveInput,jump);
        if (jump)
            jump = false;
        //jump = false;
        //MovePlayer();
        //if (facingRight == false && moveInput > 0)
        //    FlipPlayer();
        //else if (facingRight == true && moveInput < 0)
        //    FlipPlayer();
        //if( CheckIsGrounded() && jump)
        // {
        //    Jump();
        //    jump = false;
        //}
    }

    //private void Jump()
    //{
        //rgbody.velocity = Vector2.up * jumpForce;
    //}

    //private bool CheckIsGrounded()
    //{
        //return  Physics2D.OverlapCircle(groundTransform.position, checkRaduis, groundMask);
    //}

    //private void FlipPlayer()
    //{
        //facingRight = !facingRight;
        //Vector2 scaler = transform.localScale;
        //scaler.x *= -1;
        //transform.localScale = scaler;
    //}

    //private void MovePlayer()
    //{
        //rgbody.velocity = new Vector2(moveInput * speed, rgbody.velocity.y);
    //}
}
