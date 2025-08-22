using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Enemy[] enemies;
    [SerializeField] private Transform[] spawnPoints;

    public void Spawn(int index)
    {
        if (enemies.Length == 0 || spawnPoints.Length == 0)
            return;

        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemies[index], spawnPoints[spawnIndex].position, Quaternion.identity);
    }
}
