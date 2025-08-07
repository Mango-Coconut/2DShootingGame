using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable, IAttack, IMove
{
    [SerializeField] protected int health = 1;
    [SerializeField] protected float speed = 1f;
    public int Health => health;

    private void Update()
    {
        Move();
        Attack();
    }

    public virtual void Move()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    public abstract void Attack();

    public virtual void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
            Die();
    }

    protected virtual void Die()
    {
        gameObject.SetActive(false);
    }
}
