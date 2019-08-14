using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private float defaultVolume = 0.5f;

    [SerializeField] private Slider difficultySlider = null;
    [SerializeField] private int defaultDifficulty = 0;

    private MusicPlayer musicPlayer = null;

    private void Awake()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();

        musicPlayer = FindObjectOfType<MusicPlayer>();

        Coroutine volumeChangeListener = StartCoroutine("ChangeVolume");
    }

    private IEnumerator ChangeVolume()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.2f);

            musicPlayer.SetVolume(volumeSlider.value);
        }
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty((int)difficultySlider.value);
        
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }

    public void SetDefaultOptions()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}