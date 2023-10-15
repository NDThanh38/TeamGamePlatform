using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour, IGetDamage
{
    public float force;
    public float speed;
    public Rigidbody2D rigidbody2D;
    public LayerMask groundLayer;
    public Image imageFill;
    private bool canJump;
    private Animator animator;
    public float maxHP;
    private float curHP;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        curHP = maxHP;
    }


    void Update()
    {
        float directionX = 0;
        // if (Input.GetKey(KeyCode.LeftArrow))
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            directionX = -1;
            // animator.SetBool("IsRunning",true);
            animator.Play("PlayerRun");
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            directionX = 1;
            // animator.SetBool("IsRunning",true);
            animator.Play("PlayerRun");
        }
        else
        {
            directionX = 0;
            // animator.SetBool("IsRunning",false);
            animator.Play("PlayerIdle");
        }

        rigidbody2D.velocity = new Vector2(directionX * speed, rigidbody2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            Debug.Log("Nhay");
            rigidbody2D.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }

        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, -Vector2.up, 1.1f, groundLayer);

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
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Loss!");
        }
    }
    

    public void GetDamage(float damage)
    {
        if (curHP < damage)
        {
            curHP = 0;
            imageFill.fillAmount = 0;
            Die();
            return;
        }

        imageFill.fillAmount = curHP / maxHP;
        curHP -= damage;
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}