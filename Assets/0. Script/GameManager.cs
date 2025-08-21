using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int score;

    public int Score => score;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    public void RegisterScore()
    {
        LocalRanking.AddScore(score);
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            RegisterScore();
        }
    }
}
