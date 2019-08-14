using UnityEngine;

[CreateAssetMenu]
public class SoundClips : ScriptableObject
{
    [SerializeField] private AudioClip[] audios = null;

    public AudioClip GetClip(int index)
    {
        if(index >= 0 && index < audios.Length)
        {
            return audios[index];
        }else
        {
            return null;
        }
    }
}
