using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    private const string MASTER_VOLUME_KEY = "master_volume";
    private const string DIFFICULTY_KEY = "difficulty";
    private const string LEVEL_INDEX_KEY = "level_index";

    private const float MIN_VOLUME = 0f;
    private const float MAX_VOLUME = 1f;

    private const int MIN_DIFFICULTY = 0;
    private const int MAX_DIFFICULTY = 1;

    private const int MIN_LEVEL_INDEX = 3;
    private const int MAX_LEVEL_INDEX = 6;

    public static void SetMasterVolume(float volume)
    {
        if(volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Volume out of range");
        }
    }

    public static float GetMasterVolume()
    {
        float volume = PlayerPrefs.GetFloat(MASTER_VOLUME_KEY, 0.5f);

        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            return volume;
        }
        else
        {
            return MAX_VOLUME;
        }
    }

    public static void SetDifficulty(int difficulty)
    {
        if (difficulty >= MIN_DIFFICULTY && difficulty <= MAX_DIFFICULTY)
        {
            PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Difficulty out of range");
        }
    }

    public static int GetDifficulty()
    {
        int difficulty = PlayerPrefs.GetInt(DIFFICULTY_KEY, MIN_DIFFICULTY);

        if (difficulty >= MIN_DIFFICULTY && difficulty <= MAX_DIFFICULTY)
        {
            return difficulty;
        }
        else
        {
            return MIN_DIFFICULTY;
        }
    }

    public static void SetLevelIndex(int levelIndex)
    {
        // Ensure you always set a valid level index
        if (levelIndex >= MIN_LEVEL_INDEX && levelIndex <= MAX_LEVEL_INDEX)
        {
            PlayerPrefs.SetInt(LEVEL_INDEX_KEY, levelIndex);
        }
        else
        {
            Debug.LogWarning("LevelIndex out of range");
        }
    }

    public static int GetLevelIndex()
    {
        int levelIndex = PlayerPrefs.GetInt(LEVEL_INDEX_KEY, MIN_LEVEL_INDEX);

        if (levelIndex >= MIN_LEVEL_INDEX && levelIndex <= MAX_LEVEL_INDEX)
        {
            return levelIndex;
        }
        else
        {
            return MIN_LEVEL_INDEX;
        }
    }
}
