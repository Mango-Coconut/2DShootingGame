using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Enemy[] enemies;
    [SerializeField] private Transform[] spawnPoints;

    private Dictionary<string, Enemy> enemyDict;

    private void Awake()
    {
        enemyDict = new Dictionary<string, Enemy>();
        foreach (Enemy enemy in enemies)
        {
            if (enemy != null)
                enemyDict[enemy.GetType().Name] = enemy;
        }
    }

    public void Spawn(string type)
    {
        if (enemyDict.Count == 0 || spawnPoints.Length == 0)
            return;
        if (!enemyDict.TryGetValue(type, out Enemy prefab))
            return;

        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(prefab, spawnPoints[spawnIndex].position, Quaternion.identity);
    }

    public IEnumerator SpawnStage(StageInfo stage)
    {
        List<string> queue = new List<string>();
        foreach (EnemySpawnInfo info in stage.enemies)
        {
            for (int i = 0; i < info.count; i++)
                queue.Add(info.type);
        }

        while (queue.Count > 0)
        {
            int idx = Random.Range(0, queue.Count);
            string type = queue[idx];
            queue.RemoveAt(idx);
            Spawn(type);
            yield return new WaitForSeconds(Random.Range(1f, 2f));
        }
    }
}
