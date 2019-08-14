using UnityEngine;

public class Scarecrow : MonoBehaviour
{
    [SerializeField] private float explosionRadius = 1.5f;
    private LayerMask enemiesLayer;

    private void Awake()
    {
        enemiesLayer = 1 << LayerMask.NameToLayer("Enemies");
    }

    private void OnDestroy()
    {
        Collider2D [] colliders = Physics2D.OverlapCircleAll(transform.localPosition, explosionRadius, enemiesLayer);

        foreach(Collider2D collider in colliders)
        {
            var enemy = collider.gameObject.GetComponent<Health>();

            if (enemy)
            {
                enemy.DealDamage(999);
            }
        }
    }
}
