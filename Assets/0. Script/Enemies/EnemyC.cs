using UnityEngine;

public class EnemyC : Enemy
{
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private float beamInterval = 2f;
    [SerializeField] private float beamRange = 10f;
    [SerializeField] private int beamDamage = 1;

    private float attackTimer;

    protected override void Move()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    protected override void Attack()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= beamInterval)
        {
            attackTimer = 0f;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, beamRange);
            if (hit.collider != null)
            {
                Player player = hit.collider.GetComponent<Player>();
                if (player != null)
                    player.TakeDamage(beamDamage);
            }
        }
    }
}
