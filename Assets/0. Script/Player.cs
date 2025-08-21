using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private int health = 10;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float attackInterval = 0.2f;

    [SerializeField] private float spreadAngle = 10f;

    private int powerLevel = 1;
    private int bulletCount = 1;
    private float attackTimer;

    public int Health => health;
    public int PowerLevel => powerLevel;
    public int BulletCount => bulletCount;

    private void Update()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackInterval)
        {
            attackTimer = 0f;
            Attack();
        }
    }

    private void Attack()
    {
        if (firePoint == null)
            return;

        float startAngle = -(bulletCount - 1) * spreadAngle * 0.5f;
        for (int i = 0; i < bulletCount; i++)
        {
            Quaternion rot = firePoint.rotation * Quaternion.Euler(0f, 0f, startAngle + spreadAngle * i);
            PoolManager.Instance.Get<PlayerBullet>(PlayerBullet.PoolKey, firePoint.position, rot);
        }
    }

    public void Heal(int amount)
    {
        health += amount;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
            Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
        GameManager.Instance?.RegisterScore();
    }

    public void PowerUp()
    {
        powerLevel++;
        if (powerLevel % 2 == 0)
        {
            bulletCount++;
        }
        else
        {
            attackInterval = Mathf.Max(0.1f, attackInterval - 0.2f);
        }
    }
}
