using UnityEngine;

public class EnemyB : Enemy
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int bulletCount = 8;

    protected override void Move()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    protected override void Attack()
    {
        // EnemyB attacks by colliding with the player.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(1);
            SprinkleBullets();
            Die();
        }
    }

    private void SprinkleBullets()
    {
        if (bulletPrefab == null) return;

        for (int i = 0; i < bulletCount; i++)
        {
            float angle = (360f / bulletCount) * i;
            Vector2 dir = Quaternion.Euler(0f, 0f, angle) * Vector2.up;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            EnemyBullet eb = bullet.GetComponent<EnemyBullet>();
            if (eb != null)
                eb.SetDirection(dir);
        }
    }
}
