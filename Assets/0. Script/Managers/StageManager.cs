using System.Collections;
using System.Linq;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance { get; private set; }

    [SerializeField] private SpawnManager spawnManager;
    private StageData stageData;
    private int currentStage = -1;
    private int remainingEnemies;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        TextAsset json = Resources.Load<TextAsset>("Stage");
        if (json != null)
            stageData = JsonUtility.FromJson<StageData>(json.text);
    }

    private void Start()
    {
        NextStage();
    }

    public void EnemyDefeated()
    {
        remainingEnemies--;
        if (remainingEnemies <= 0)
            NextStage();
    }

    private void NextStage()
    {
        currentStage++;
        if (stageData == null || currentStage >= stageData.stages.Length)
        {
            Debug.Log("All stages cleared!");
            return;
        }

        StageInfo stage = stageData.stages[currentStage];
        StageNoticeUI.Show(currentStage + 1);
        remainingEnemies = stage.enemies.Sum(e => e.count);
        StartCoroutine(spawnManager.SpawnStage(stage));
    }
}
