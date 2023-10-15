using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float force;
    public float speed;
    public Rigidbody2D rigidbody2D;
    public LayerMask groundLayer;
    private bool canJump;
    private Animator animator;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }


    void Update()
    {
        float directionX = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            directionX = -1;
            animator.SetBool("IsRunning",true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(1, 1, 1);
            directionX = 1;
            animator.SetBool("IsRunning",true);
        }
        else
        {
            directionX = 0;
            animator.SetBool("IsRunning",false);
        }

        rigidbody2D.velocity = new Vector2(directionX * speed,rigidbody2D.velocity.y) ;

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            Debug.Log("Nhay");
            rigidbody2D.AddForce(Vector2.up * force,ForceMode2D.Impulse);
        }

        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, -Vector2.up, 1.1f,groundLayer);
        
        Debug.DrawRay(transform.position, -Vector2.up * 1.1f, Color.black);
        
        if (raycastHit2D.collider != null)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Loss!");
        }
    }
}
