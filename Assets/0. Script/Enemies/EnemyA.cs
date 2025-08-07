using UnityEngine;

public class EnemyA : Enemy
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireInterval = 1f;

    private float fireTimer;

    private void Awake()
    {
        speed = 2f;
    }

    public override void Attack()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer >= fireInterval)
        {
            fireTimer = 0f;
            if (bulletPrefab != null)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                EnemyBullet eb = bullet.GetComponent<EnemyBullet>();
                if (eb != null)
                    eb.SetDirection(Vector2.down);
            }
        }
    }
}
