using System.Collections;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    //----------------- NEW ----------------------- 
    [SerializeField] private Wave wave = null;
    [SerializeField] private EnemiesLaneConstants enemiesConstants = null;
    private int index = 0;
    private int maxIndex = 0;
    //--------------------------------------------- 

    //---------------- OLD ------------------------
    //[SerializeField] private float minSpawnDelay = 1f;
    //[SerializeField] private float maxSpawnDelay = 5f;
    //[SerializeField] private Attacker [] attackersPrefab = null;
    //[SerializeField] private float [] attackersSpawnOffset = null;
    //---------------------------------------------

    //-------- BOTH -------------------------------
    private float delay = 0f;
    private bool spawn = true;
    private Coroutine spawnRoutine = null;

    private void Start()
    {
        maxIndex = wave.GetMaxIndex(); // NEW
        spawnRoutine = StartCoroutine(SpawnAttackers());
    }

    private IEnumerator SpawnAttackers()
    {
        while (index < maxIndex && spawn)
        {
            delay = wave.GetTimeBetweenSpawns(index);

            yield return new WaitForSeconds(delay);

            if (spawn)
            {
                Spawn(index);
                index++;
            }
        }
    }

    private void Spawn(int index)
    {
        int enemyPrefabIndex = wave.GetEnemyPrefabIndex(index);

        Attacker attacker = Instantiate(enemiesConstants.GetEnemyPrefab(enemyPrefabIndex), transform.position + new Vector3(enemiesConstants.GetEnemySpawnOffset(enemyPrefabIndex), 0f, 0f), Quaternion.identity, transform) as Attacker;

        int sortingLayer = 8;

        if (attacker.GetComponent<Fox>())
        {
            sortingLayer = 7;
        }

        attacker.SetSortingOrder(sortingLayer - (int)transform.position.y);
    }

    public void SetWave(Wave wave)
    {
        this.wave = wave;
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    /*
    private IEnumerator SpawnAttackers()
    {
        while (spawn)
        {
            delay = UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay);

            yield return new WaitForSeconds(delay);

            if(spawn)
            {
                Spawn(UnityEngine.Random.Range(0, attackersPrefab.Length));
            }
        }
    }

    private void Spawn(int index)
    {
        Attacker attacker = Instantiate(attackersPrefab[index], transform.position + new Vector3(attackersSpawnOffset[index], 0f, 0f), Quaternion.identity, transform) as Attacker;

        attacker.SetSortingOrder(7 - (int)transform.position.y);
    }
    */
}