using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] private int initialStars = 500;
    public static int stars;
    private static Text textDisplay = null;
    private static bool gameRunning;

    private void Awake()
    {
        stars = initialStars;
        gameRunning = true;
        textDisplay = GetComponent<Text>();
        UpdateDisplay();
    }

    private static void UpdateDisplay()
    {
        textDisplay.text = stars.ToString();
    }

    public static void AddStars(int starsToAdd)
    {
        if (gameRunning)
        {
            stars += starsToAdd;
            UpdateDisplay();
        }
    }

    public static void GameOver()
    {
        gameRunning = false;
    }

    public static bool HaveEnoughStars(int starsToSpend)
    {
        if (stars >= starsToSpend)
        {
            return true;
        }

        return false;
    }

    public static void SpendStars(int starsToSpend)
    {
        stars -= starsToSpend;
        UpdateDisplay();
    }
}