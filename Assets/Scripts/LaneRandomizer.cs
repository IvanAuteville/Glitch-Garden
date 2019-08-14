using UnityEngine;

public class LaneRandomizer : MonoBehaviour
{
    [SerializeField] private Wave[] waves = null;
    private AttackerSpawner[] lanes = null;

    private void Awake()
    {
        lanes = GetComponentsInChildren<AttackerSpawner>();

        RandomizeWaves();
        SetAllWaves();
    }

    private void SetAllWaves()
    {
        for (int i = 0; i < lanes.Length; i++)
        {
            lanes[i].SetWave(waves[i]);
        }
    }

    private void RandomizeWaves()
    {
        // Fisher–Yates shuffle Algorithm
        for (int i = waves.Length - 1; i > 0; i--)
        {
            int random = UnityEngine.Random.Range(0, i + 1); // [0, i]

            Wave aux = waves[i];

            waves[i] = waves[random];
            waves[random] = aux;
        }
    }
}