using UnityEngine;

public class EmergencyDefender : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2f;
    [SerializeField] private SoundClips sounds = null;

    private void Start()
    {
        // Sound
        AudioSource.PlayClipAtPoint(sounds.GetClip(0), transform.localPosition, PlayerPrefsController.GetMasterVolume());
    }

    void Update()
    {
        transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Attacker>())
        {
            collision.gameObject.GetComponent<Health>().DealDamage(999);
        }
    }
}