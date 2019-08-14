using UnityEngine;

public class DefendersButtons : MonoBehaviour
{
    [SerializeField] private Level level = null;
    private static DefenderButton [] defenders = null;

    private void Awake()
    {
        DisableDefendersByLevel();
    }

    // By default all defenders are enabled
    // Disable according to the level the ones that are not required
    private void DisableDefendersByLevel()
    {
        defenders = FindObjectsOfType<DefenderButton>();

        int maxIdentifier = level.GetLevel() + 1;

        foreach (DefenderButton defender in defenders)
        {
            if (defender.GetIdentifier() > maxIdentifier)
            {
                defender.Disable();
            }
        }
    }

    // Set transparency back to "not selected"
    public static void ResetButtons()
    {
        foreach (DefenderButton defender in defenders)
        {
            defender.ResetButton();
        }
    }
}