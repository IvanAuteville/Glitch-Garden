using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private float splashScreenDelayTime = 3.3f;
    [SerializeField] private Level level = null;

    private MusicPlayer musicPlayer = null;
    private int currentSceneIndex;

    void Awake()
    {
        musicPlayer = FindObjectOfType<MusicPlayer>();

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        level.SetLevel(currentSceneIndex);

        if(currentSceneIndex == 0)
        {
            LoadLevel(++currentSceneIndex, splashScreenDelayTime);
        }
    }

    public void LoadLevel(int index)
    {
        currentSceneIndex = index;
        level.SetLevel(currentSceneIndex);

        SceneManager.LoadScene(index);
        musicPlayer.LevelChanged(currentSceneIndex);
    }

    public void LoadGame()
    {
        currentSceneIndex = PlayerPrefsController.GetLevelIndex();
        SceneManager.LoadSceneAsync(currentSceneIndex);

        level.SetLevel(currentSceneIndex);
        musicPlayer.LevelChanged(currentSceneIndex);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
        musicPlayer.RestartLevelMusic();
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        currentSceneIndex = 1;
        level.SetLevel(currentSceneIndex);

        musicPlayer.LevelChanged(currentSceneIndex);
    }

    public void LoadOptionsMenu()
    {
        SceneManager.LoadScene(2);
        currentSceneIndex = 2;
        level.SetLevel(currentSceneIndex);
    }

    public void LoadLevel(int index, float delaySeconds)
    {
        currentSceneIndex = index;
        level.SetLevel(currentSceneIndex);

        StartCoroutine(WaitForSecondsAndLoad(delaySeconds, index));
    }

    public void LoadNextLevel()
    {
        currentSceneIndex++;
        level.SetLevel(currentSceneIndex);

        SceneManager.LoadScene(currentSceneIndex);
        musicPlayer.LevelChanged(currentSceneIndex);
    }

    public IEnumerator WaitForSecondsAndLoad(float seconds, int index)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(index);
        musicPlayer.LevelChanged(currentSceneIndex);
    }

    public void Quit()
    {
        Application.Quit(); 
    }
}