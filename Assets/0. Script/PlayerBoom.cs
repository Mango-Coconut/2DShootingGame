using UnityEngine;

public class PlayerBoom : MonoBehaviour
{
    [SerializeField] private float radius = 3f;
    [SerializeField] private int damage = 10;
    [SerializeField] private int boomCount = 0;

    public int BoomCount => boomCount;

    public void AddBoom(int amount)
    {
        boomCount += amount;
    }

    public void Boom()
    {
        if (boomCount <= 0)
            return;

        boomCount--;

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (var hit in hits)
        {
            Enemy enemy = hit.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
#endif
}
