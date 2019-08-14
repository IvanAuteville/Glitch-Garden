using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private Level level = null;
    private float levelDuration = 0f;

    private Slider slider = null;
    private float amountToMove;

    private Animator animator = null;
    private bool animationEnabled = true;

    private LevelController levelController = null;
    
    public void Awake()
    {
        levelController = FindObjectOfType<LevelController>();

        slider = GetComponent<Slider>();
        animator = GetComponentInChildren<Animator>();

        levelDuration = level.GetLevelDuration();
        amountToMove = slider.maxValue / levelDuration;
    }

    private void Update()
    {
        if(slider.value < slider.maxValue)
        {
            slider.value += amountToMove * Time.deltaTime;
        }else
        {
            if(animationEnabled)
            {
                animator.enabled = false;
                animationEnabled = false;
            }

            levelController.TimeEnded();
        }
    }
}