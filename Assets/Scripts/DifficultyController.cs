using UnityEngine;

public class DifficultyController : MonoBehaviour
{
    private void Awake()
    {
        if(PlayerPrefsController.GetDifficulty() == 1)
        {
            gameObject.SetActive(false);
        }
    }
}
