using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public const string PoolKey = "PlayerBullet";

    [SerializeField] private float speed = 10f;
    [SerializeField] private int damage = 1;
    [SerializeField] private float lifeTime = 3f;

    private float lifeTimer;

    private void OnEnable()
    {
        lifeTimer = 0f;
    }

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        lifeTimer += Time.deltaTime;
        if (lifeTimer >= lifeTime)
        {
            PoolManager.Instance.Return(PoolKey, this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable target = collision.GetComponent<IDamageable>();
        if (target != null && collision.tag != "Player")
        {
            target.TakeDamage(damage);
            PoolManager.Instance.Return(PoolKey, this);
        }
    }
}
