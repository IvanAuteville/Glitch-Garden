using UnityEngine;
using UnityEngine.UI;


public class LevelText : MonoBehaviour
{
    private Text levelText;
    [SerializeField] private Level level = null;

    private void Awake()
    {
        levelText = GetComponent<Text>();
        levelText.text = "Level " + level.GetLevel() + " Progress";
    }
}