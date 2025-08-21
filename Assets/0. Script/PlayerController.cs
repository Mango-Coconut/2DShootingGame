using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerBoom))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Player player;
    private PlayerBoom boom;

    private void Awake()
    {
        player = GetComponent<Player>();
        boom = GetComponent<PlayerBoom>();
    }

    private void Update()
    {
        HandleMovement();
        if (Input.GetKeyDown(KeyCode.X))
        {
            boom?.Boom();
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
