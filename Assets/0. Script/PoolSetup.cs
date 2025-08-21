using UnityEngine;

public class PoolSetup : MonoBehaviour
{
    [SerializeField] private PlayerBullet playerBulletPrefab;
    [SerializeField] private int playerBulletSize = 10;
    [SerializeField] private EnemyBullet enemyBulletPrefab;
    [SerializeField] private int enemyBulletSize = 10;
    [SerializeField] private PlayerBoomProjectile playerBoomPrefab;
    [SerializeField] private int playerBoomSize = 1;

    private void Awake()
    {
        if (playerBulletPrefab != null)
            PoolManager.Instance.Register(PlayerBullet.PoolKey, playerBulletPrefab, playerBulletSize);
        if (enemyBulletPrefab != null)
            PoolManager.Instance.Register(EnemyBullet.PoolKey, enemyBulletPrefab, enemyBulletSize);
        if (playerBoomPrefab != null)
            PoolManager.Instance.Register(PlayerBoomProjectile.PoolKey, playerBoomPrefab, playerBoomSize);
    }
}
