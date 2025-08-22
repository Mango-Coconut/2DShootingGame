using System;

[Serializable]
public class StageData
{
    public StageInfo[] stages;
}

[Serializable]
public class StageInfo
{
    public EnemySpawnInfo[] enemies;
}

[Serializable]
public class EnemySpawnInfo
{
    public string type;
    public int count;
}
