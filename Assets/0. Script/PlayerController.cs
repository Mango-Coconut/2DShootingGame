using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        HandleMovement();
        if (Input.GetButtonDown("Fire1"))
        {
            player.Attack();
        }
    }

    private void HandleMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(x, y, 0f).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
}
