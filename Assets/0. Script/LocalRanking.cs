using UnityEngine;

public static class LocalRanking
{
    private const string KeyFormat = "LocalRank_{0}";
    private const int MaxRank = 5;

    public static void AddScore(int score)
    {
        int[] ranks = GetScores();
        for (int i = 0; i < MaxRank; i++)
        {
            if (score > ranks[i])
            {
                for (int j = MaxRank - 1; j > i; j--)
                {
                    ranks[j] = ranks[j - 1];
                }
                ranks[i] = score;
                break;
            }
        }

        for (int i = 0; i < MaxRank; i++)
        {
            PlayerPrefs.SetInt(string.Format(KeyFormat, i), ranks[i]);
        }
        PlayerPrefs.Save();
    }

    public static int[] GetScores()
    {
        int[] ranks = new int[MaxRank];
        for (int i = 0; i < MaxRank; i++)
        {
            ranks[i] = PlayerPrefs.GetInt(string.Format(KeyFormat, i), 0);
        }
        return ranks;
    }
}
