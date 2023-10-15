using UnityEngine;

public class Enemy : MonoBehaviour, IGetDamage
{
    public float damage;
    public float speed;
    protected Vector3 dir;
    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        LevelCtl.Instance.CheckWin();
    }

    public virtual void Move()
    {
        gameObject.transform.Translate(dir * speed * Time.deltaTime);
    }

    public virtual void GetDamage(float damage)
    {
        throw new System.NotImplementedException();
    }

    public virtual void Die()
    {
        throw new System.NotImplementedException();
    }
}