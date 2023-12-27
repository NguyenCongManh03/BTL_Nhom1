using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    private float dirX = 0f;
    [SerializeField]private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;

    private enum MovementState { idle, running, jumping, falling}

    [SerializeField] private AudioSource jumpSoundEffect;
    // Flip
    public bool isFacingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        
    }
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }
    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0f && !isFacingRight)
        {
            state = MovementState.running;
            //sprite.flipX = false;
            Flip();
            
        }
        else if (dirX < 0f && isFacingRight)
        {
            state = MovementState.running;
            //sprite.flipX = true;
            Flip();
            
        }
        else
        {
            state = MovementState.idle;
            
        }
        if(rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if(rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
    }
    private bool IsGrounded()
    {
       return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
