using UnityEngine;

public class EnemyC : Enemy
{
    [SerializeField] private float beamInterval = 2f;
    [SerializeField] private float beamRange = 10f;
    [SerializeField] private int beamDamage = 1;
    [SerializeField] private float rotateSpeed = 180f;

    private float attackTimer;
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
        attackTimer += Time.deltaTime;
        if (attackTimer >= beamInterval)
        {
            attackTimer = 0f;
            if (player == null)
                return;

            Vector2 dir = (player.position - transform.position).normalized;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, beamRange);
            if (hit.collider != null)
            {
                Player playerHit = hit.collider.GetComponent<Player>();
                if (playerHit != null)
                    playerHit.TakeDamage(beamDamage);
            }
        }
    }
}
