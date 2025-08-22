using UnityEngine;

public class EnemyA : Enemy
{
    [SerializeField] private float fireInterval = 1f;
    [SerializeField] private float rotateSpeed = 180f;

    private float fireTimer;
    private Transform player;

    private void Start()
    {
        player = FindObjectOfType<Player>()?.transform;
    }

    public override void Move()
    {
        base.Move();
        RotateTowardsPlayer();
    }

    private void RotateTowardsPlayer()
    {
        if (player == null)
            return;

        Vector2 dir = player.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90f;
        Quaternion target = Quaternion.Euler(0f, 0f, angle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target, rotateSpeed * Time.deltaTime);
    }

    public override void Attack()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer >= fireInterval)
        {
            fireTimer = 0f;
            EnemyBullet bullet = PoolManager.Instance.Get<EnemyBullet>(
                EnemyBullet.PoolKey, transform.position, Quaternion.identity);
            if (bullet != null)
            {
                Vector2 dir = player != null ? (player.position - transform.position).normalized : Vector2.down;
                bullet.Fire(dir);
            }
        }
    }
}
