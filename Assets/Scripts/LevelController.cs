using System;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject winCanvas = null;
    [SerializeField] private GameObject loseCanvas = null;
    [SerializeField] private GameObject pauseCanvas = null;
    [SerializeField] private Level level = null;
    [SerializeField] private float delayBeforeNextLevel = 2f;
    [SerializeField] private float lastLevelDelay = 6f;
    [SerializeField] private int maxLevel = 0;
    [SerializeField] private int mainMenuIndex = 1;
    [SerializeField] private int offsetIndex = 2;

    public static int attackersAlive = 0;
    private AttackerSpawner[] spawnerArray = null;

    private bool timeEnded = false;
    public static bool gamePaused = false;
    public static bool gameOver = false;

    private MusicPlayer musicPlayer = null;

    private void Awake()
    {
        gameOver = false;
        gamePaused = false;

        spawnerArray = FindObjectsOfType<AttackerSpawner>();
        musicPlayer = FindObjectOfType<MusicPlayer>();
        maxLevel = level.GetLastLevel();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && CanPause())
        {
            ManagePause();
        }
    }

    private void ManagePause()
    {
        if(gamePaused)
        {
            UnpauseGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1f;
        gamePaused = false;
        pauseCanvas.SetActive(false);
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        gamePaused = true;
        pauseCanvas.SetActive(true);
    }

    public void TimeEnded()
    {
        if(!timeEnded)
        {
            timeEnded = true;
            StopSpawners();
        }

        if(attackersAlive == 0 && !gameOver)
        {
            gameOver = true;
            GameWon();
        }
    }

    public static void AddAttacker()
    {
        attackersAlive++;
    }

    public static void SubtractAttacker()
    {
        attackersAlive--;
    }

    private void StopSpawners()
    {
        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }

    private void GameWon()
    {
        StarDisplay.GameOver();
        winCanvas.SetActive(true);

        int gameLevel = level.GetLevel();
        int levelIndex = gameLevel + offsetIndex;

        if(gameLevel != maxLevel)
        {
            musicPlayer.PlayVictorySound(false);
            GetComponent<LevelLoader>().LoadLevel(++levelIndex, delayBeforeNextLevel);
        }else // Load Main Menu
        {
            musicPlayer.PlayVictorySound(true);

            // Game won, so the next time we hit play start from the first level
            PlayerPrefsController.SetLevelIndex(3);
            //--------------------------------------

            GetComponent<LevelLoader>().LoadLevel(mainMenuIndex, lastLevelDelay);
        }
    }

    public void GameLost()
    {
        StarDisplay.GameOver();

        gameOver = true;
        Time.timeScale = 0;

        loseCanvas.SetActive(true);
        musicPlayer.PlayDefeatSound();
    }

    private bool CanPause()
    {
        return !gameOver;
    }
}