using UnityEngine;

public class PlayerBoom : MonoBehaviour
{
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

        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, 0f);
        PoolManager.Instance.Get<PlayerBoomProjectile>(PlayerBoomProjectile.PoolKey, spawnPos, Quaternion.identity);
    }
}
