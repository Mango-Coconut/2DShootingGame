using UnityEngine;

public class PlayerBoomProjectile : MonoBehaviour
{
    public const string PoolKey = "PlayerBoom";

    [SerializeField] private float speed = 5f;
    [SerializeField] private int damage = 1;

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        if (transform.position.y >= 10f)
        {
            PoolManager.Instance.Return(PoolKey, this);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        IDamageable target = collision.GetComponent<IDamageable>();
        if (target != null && collision.tag != "Player")
        {
            target.TakeDamage(damage);
        }
    }
}
