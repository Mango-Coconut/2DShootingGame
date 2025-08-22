using UnityEngine;

public class EnemyB : Enemy
{
    [SerializeField] private int bulletCount = 8;
    [SerializeField] private float acceleration = 1f;
    [SerializeField] private float accelerationIncrease = 0.5f;

    private float horizontalSpeed;
    private float verticalSpeed;
    private float currentAcceleration;
    private Transform player;

    private void Start()
    {
        player = FindObjectOfType<Player>()?.transform;

        Vector2 dir = player != null
            ? ((Vector2)(player.position - transform.position)).normalized
            : Vector2.down;

        horizontalSpeed = dir.x * speed;
        verticalSpeed = Mathf.Abs(dir.y) * speed;
        currentAcceleration = acceleration;
    }

    public override void Move()
    {
        verticalSpeed += currentAcceleration * Time.deltaTime;
        currentAcceleration += accelerationIncrease * Time.deltaTime;

        Vector2 move = new Vector2(horizontalSpeed, -verticalSpeed) * Time.deltaTime;
        transform.Translate(move, Space.World);
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
