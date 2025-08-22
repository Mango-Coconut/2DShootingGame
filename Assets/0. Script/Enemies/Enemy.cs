using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable, IAttack, IMove
{
    [SerializeField] private EnemyStats stats;

    protected int health;
    protected float speed;
    public int Health => health;

    protected virtual void Awake()
    {
        if (stats != null)
            ApplyStats(stats);
    }

    public void ApplyStats(EnemyStats newStats)
    {
        stats = newStats;
        health = stats.health;
        speed = stats.speed;
    }

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
        DamageText.Create(amount, transform.position);
        if (health <= 0)
            Die();
    }

    protected virtual void Die()
    {
        gameObject.SetActive(false);
        StageManager.Instance?.EnemyDefeated();
    }
}
