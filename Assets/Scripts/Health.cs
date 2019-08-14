using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    [SerializeField] private GameObject deathVFXPrefab = null;
    [SerializeField] private GameObject hitVFXPrefab = null;
    [SerializeField] private SoundClips sounds = null;

    public void DealDamage(float damage)
    {
        health -= damage;

        if (health <= 0f)
        {
            GameObject deathVFX = Instantiate(deathVFXPrefab, transform.position + (Vector3.back * 5), Quaternion.identity) as GameObject;

            // Play Sound
            AudioSource.PlayClipAtPoint(sounds.GetClip(0), transform.localPosition, PlayerPrefsController.GetMasterVolume());

            Destroy(gameObject);
        }else
        {
            GameObject hitVFX = Instantiate(hitVFXPrefab, transform.position + (Vector3.back * 5), Quaternion.identity) as GameObject;
        }
    }
}