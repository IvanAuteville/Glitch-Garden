using UnityEngine;

[CreateAssetMenu(menuName = "EnemiesLaneConstants")]
public class EnemiesLaneConstants : ScriptableObject
{
    [SerializeField] private Attacker[] enemyPrefabs = null;
    [SerializeField] private float[] enemiesSpawnOffset = null;

    public Attacker GetEnemyPrefab(int prefabIndex)
    {
        return enemyPrefabs[prefabIndex];
    }

    public float GetEnemySpawnOffset(int prefabIndex)
    {
        return enemiesSpawnOffset[prefabIndex];
    }
}