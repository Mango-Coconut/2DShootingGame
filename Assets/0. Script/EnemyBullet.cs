using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public const string PoolKey = "EnemyBullet";

    [SerializeField] private float speed = 5f;
    [SerializeField] private int damage = 1;
    [SerializeField] private float lifeTime = 5f;

    private Vector2 direction = Vector2.down;
    private float lifeTimer;

    private void OnEnable()
    {
        lifeTimer = 0f;
        direction = Vector2.down;
    }

    public void Fire(Vector2 dir)
    {
        direction = dir.normalized;
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        lifeTimer += Time.deltaTime;
        if (lifeTimer >= lifeTime)
        {
            PoolManager.Instance.Return(PoolKey, this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable target = collision.GetComponent<IDamageable>();
        if (target != null && collision.tag != "Enemy")
        {
            target.TakeDamage(damage);
            PoolManager.Instance.Return(PoolKey, this);
        }
    }
}
