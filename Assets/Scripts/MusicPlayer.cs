using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip splashScreenSound = null;
    [SerializeField] private AudioClip menuScreenSound = null;
    [SerializeField] private AudioClip gameMusic = null;

    [SerializeField] private AudioClip victorySound = null;
    [SerializeField] private AudioClip defeatSound = null;
    [SerializeField] private AudioClip gameWon = null;

    private AudioSource audioSource = null;
    private AudioClip levelMusicAux = null;

    private void Awake()
    {
        SetUpSingleton();

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsController.GetMasterVolume();

        PlaySplashScreenSound();
    }

    private void SetUpSingleton()
    {
        if(FindObjectsOfType<MusicPlayer>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this);
        }
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void LevelChanged(int index)
    {
        audioSource.loop = true;

        if (index > 0 && index < 3)
        {
            if (audioSource.clip != menuScreenSound)
            {
                audioSource.Stop();
                audioSource.clip = menuScreenSound;
                audioSource.Play();
            }
        }else if(index >= 3)
        {
            audioSource.Stop();
            audioSource.clip = gameMusic;
            audioSource.Play();
        }
    }

    private void PlaySplashScreenSound()
    {
        audioSource.clip = splashScreenSound;
        audioSource.Play();
    }

    public void PlayVictorySound(bool lastLevel)
    {
        audioSource.Stop();

        if(lastLevel)
        {
            audioSource.clip = gameWon;
        }
        else
        {
            audioSource.clip = victorySound;
        }

        audioSource.loop = false;
        audioSource.Play();
    }

    public void PlayDefeatSound()
    {
        levelMusicAux = audioSource.clip;

        audioSource.Stop();
        audioSource.clip = defeatSound;
        audioSource.Play();
    }

    public void RestartLevelMusic()
    {
        audioSource.Stop();
        audioSource.clip = levelMusicAux;
        audioSource.Play();
    }
}
