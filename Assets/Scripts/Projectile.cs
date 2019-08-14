using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private AudioClip spawnSound = null;
    [SerializeField] private AudioClip impactSound = null;

    private void Start()
    {
        AudioSource.PlayClipAtPoint(spawnSound, transform.localPosition);
    }

    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Health enemyHealth = other.GetComponent<Health>();

        if (enemyHealth)
        {
            enemyHealth.DealDamage(damage);

            AudioSource.PlayClipAtPoint(impactSound, transform.localPosition);

            Destroy(gameObject);
        }
    }
}
