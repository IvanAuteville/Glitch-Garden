using UnityEngine;

public class EmergencySpawner : MonoBehaviour
{
    [SerializeField] private EmergencyDefender defender = null;
    [SerializeField] private float offsetDistance = -1f;
    private Collider2D boxCollider = null;

    private void Awake()
    {
        boxCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D()
    {
        Instantiate(defender, transform.position + new Vector3(offsetDistance, 0f, 0f), Quaternion.identity, transform);

        Destroy(boxCollider);
    }
}