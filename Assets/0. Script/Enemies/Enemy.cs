using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private int health = 1;
    public int Health => health;

    private void Update()
    {
        Move();
        Attack();
    }

    protected abstract void Move();
    protected abstract void Attack();

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
