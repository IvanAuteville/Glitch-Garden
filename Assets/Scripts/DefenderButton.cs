using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] private int identifier = 0;
    [SerializeField] private Defender defenderPrefab = null;
    [SerializeField] private SoundClips sounds = null;

    private SpriteRenderer spriteRenderer = null;
    private Text starCostText = null;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        starCostText = GetComponentInChildren<Text>();
        starCostText.text = defenderPrefab.GetStarCost().ToString();
    }

    private void OnMouseDown()
    {
        if(!LevelController.gameOver && !LevelController.gamePaused)
        {
            DefendersButtons.ResetButtons();
            spriteRenderer.color = Color.white;

            DefenderSpawner.SetSelectedDefender(defenderPrefab);
            
            // Play Sound
            AudioSource.PlayClipAtPoint(sounds.GetClip(0), transform.localPosition, PlayerPrefsController.GetMasterVolume());
        }
    }

    public void ResetButton()
    {
        spriteRenderer.color = new Color32(255, 255, 255, 100);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public int GetIdentifier()
    {
        return identifier;
    }
}