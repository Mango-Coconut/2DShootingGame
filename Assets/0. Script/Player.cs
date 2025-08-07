using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private int health = 10;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float attackInterval = 0.2f;

    private float attackTimer;

    public int Health => health;

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
        if (bulletPrefab == null || firePoint == null)
            return;

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
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
    }
}
