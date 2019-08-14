using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab = null;
    [SerializeField] private GameObject spawnPosition = null;
    private AttackerSpawner laneSpawner = null;

    //Animator
    private Animator animator = null;
    private string isAttacking = "isAttacking";

    private void Awake()
    {
        animator = GetComponent<Animator>();
        SetLaneSpawner();
    }

    private void Update()
    {
        if(IsAttackerInLane())
        {
            animator.SetBool(isAttacking, true);
        }
        else
        {
            animator.SetBool(isAttacking, false);
        }
    }

    private bool IsAttackerInLane()
    {
        if (laneSpawner.transform.childCount > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] lanes = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in lanes)
        {
            if ((int)spawner.transform.localPosition.y - (int)transform.localPosition.y == 0) // <= Mathf.Epsilon)
            {
                laneSpawner = spawner;
                break;
            }
        }
    }

    public void Fire()
    {
        GameObject projectile = Instantiate(projectilePrefab, spawnPosition.transform) as GameObject;
        projectile.GetComponentInChildren<SpriteRenderer>().sortingOrder = 10;
    }
}
