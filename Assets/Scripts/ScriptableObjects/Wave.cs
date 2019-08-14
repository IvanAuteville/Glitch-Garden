using UnityEngine;

[CreateAssetMenu(menuName = "Wave")]
public class Wave : ScriptableObject
{
    [SerializeField] private int[] timeBetweenSpawns = null;
    [SerializeField] private int[] enemyPrefabIndex = null;

    public int GetMaxIndex()
    {
        return timeBetweenSpawns.Length;
    }

    public int GetTimeBetweenSpawns(int index)
    {
        return timeBetweenSpawns[index];
    }

    public int GetEnemyPrefabIndex(int index)
    {
        return enemyPrefabIndex[index];
    }
}