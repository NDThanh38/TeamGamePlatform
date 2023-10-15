using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigEnemy : Enemy
{
    public LayerMask playerLayer;

    private void Awake()
    {
        dir = Vector3.right;
    }

    private void Update()
    {
        Move();
    }


    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, Vector2.up, 1.25f, playerLayer);
            if (raycastHit2D.collider != null)
            {
                //cong diem player
                Debug.Log("Hit enemy");
                Die();
            }
            else
            {
                other.GetComponent<IGetDamage>().GetDamage(damage);
            }
        }
        else if (other.gameObject.tag == "ChangeDirection")
        {
            speed *= -1;
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
        base.OnTriggerEnter2D(other);
    }

    public override void Die()
    {
        gameObject.SetActive(false);
    }
}