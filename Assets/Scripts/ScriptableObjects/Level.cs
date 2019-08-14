using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Level")]
public class Level : ScriptableObject
{
    [SerializeField] private int currentLevel = 1;
    [SerializeField] private int buildIndexOffset = 2;
    [SerializeField] private int lastLevel = 5;
    [SerializeField] private float[] levelDurations = null;

    public int GetLevel()
    {
        return currentLevel;
    }

    public int GetLastLevel()
    {
        return lastLevel;
    }

    public void SetLevel(int levelIndex)
    {
        // The index validation is done inside SetLevelIndex
        PlayerPrefsController.SetLevelIndex(levelIndex);

        currentLevel = levelIndex - buildIndexOffset;
    }

    public float GetLevelDuration()
    {
        return levelDurations[currentLevel - 1];
    }
}