using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private int health = 10;
    private IWeapon weapon;

    public int Health => health;

    public void Initialize(IWeapon initialWeapon)
    {
        weapon = initialWeapon;
    }

    public void Attack()
    {
        weapon?.Fire();
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
