using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabMove : MonoBehaviour
{
    public Transform _pointCheck;
    public float moveDirection;
    public float moveSpeed;
    bool isFacingRight = true;
    bool CheckingGround;
    public LayerMask Ground;
    public LayerMask Player;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        moveDirection = 1;
        CheckingGround = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        CheckingGround = Physics2D.OverlapCircle(_pointCheck.position, 0.5f, Ground);
        
    }

    private void Move()
    {
        if (!CheckingGround)
        {
            if(isFacingRight)
            {
                Flip();
            }
            else if(!isFacingRight)
            {
                Flip();
            }
        }
        rb.velocity = new Vector2(moveDirection * moveSpeed,rb.velocity.y);
    }
    void Flip()
    {
        moveDirection *= -1;
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
