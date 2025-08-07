using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public abstract void Apply(Player player);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            Apply(player);
            Destroy(gameObject);
        }
    }
}
