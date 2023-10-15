using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigEnemy : MonoBehaviour
{
    public LayerMask playerLayer;
    public float speed;

    private void Update()
    {
        gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
        
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, Vector2.up, 1.25f,playerLayer);
            if (raycastHit2D.collider != null)
            {
                //cong diem player
                Debug.Log("Hit enemy");
                Destroy(gameObject);
            }
        }
        else if (other.gameObject.tag == "ChangeDirection")
        {
            speed *= -1;
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
    }
}
