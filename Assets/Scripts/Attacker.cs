using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 1f)] [SerializeField] private float movementSpeed = 0f;
    [SerializeField] private float attackDamage = 25f;
    [SerializeField] private SoundClips sounds = null;
    private float currentMovementSpeed = 0f;

    private GameObject currentTarget = null;
    private Animator animator = null;
    private SpriteRenderer[] spriteRenderer = null;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponentsInChildren<SpriteRenderer>();

        LevelController.AddAttacker();
    }

    private void OnDestroy()
    {
        LevelController.SubtractAttacker();
    }

    void Update()
    {
        transform.Translate(Vector2.left * currentMovementSpeed * Time.deltaTime);

        UpdateAnimationState();
    }

    public void SetSortingOrder(int order)
    {
        foreach (SpriteRenderer sprite in spriteRenderer)
        {
            sprite.sortingOrder = order;
        }
    }

    private void UpdateAnimationState()
    {
        if(!currentTarget && animator.GetBool("isAttacking"))
        {
            animator.SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed(float amount)
    {
        currentMovementSpeed = amount;
    }

    public void Move()
    {
        currentMovementSpeed = movementSpeed;
    }

    public void Stop()
    {
        currentMovementSpeed = 0f;
    }

    public void Attack(GameObject target)
    {
        animator.SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget()
    {
        // If there is a target
        if(currentTarget)
        {
            currentTarget.GetComponent<Health>().DealDamage(attackDamage);
            AudioSource.PlayClipAtPoint(sounds.GetClip(Random.Range(0, 2)), transform.localPosition);
        }
    }
}