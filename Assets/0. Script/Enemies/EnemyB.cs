using UnityEngine;

public class EnemyB : Enemy
{
    [SerializeField] private int bulletCount = 8;

    private void Awake()
    {
        speed = 3f;
    }

    public override void Attack()
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
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = (360f / bulletCount) * i;
            Vector2 dir = Quaternion.Euler(0f, 0f, angle) * Vector2.up;
            EnemyBullet bullet = PoolManager.Instance.Get<EnemyBullet>(
                EnemyBullet.PoolKey, transform.position, Quaternion.identity);
            if (bullet != null)
                bullet.Fire(dir);
        }
    }
}
