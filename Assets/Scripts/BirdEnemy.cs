using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdEnemy : Enemy
{
    private void Update()
    {
        // transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        dir = LevelCtl.Instance.player.transform.position - transform.position;
        Move();
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<IGetDamage>().GetDamage(damage);
        Die();
        base.OnTriggerEnter2D(other);
    }

    public override void Die()
    {
        gameObject.SetActive(false);
    }
}