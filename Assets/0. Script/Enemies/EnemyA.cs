using UnityEngine;

public class EnemyA : Enemy
{
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
            EnemyBullet bullet = PoolManager.Instance.Get<EnemyBullet>(
                EnemyBullet.PoolKey, transform.position, Quaternion.identity);
            if (bullet != null)
            {
                bullet.Fire(Vector2.down);
            }
        }
    }
}
