using UnityEngine;

public class SoundManager : SingletonMonoBehavior<SoundManager>
{
    [SerializeField] private AudioSource audioSource;

    public void PlaySound(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.PlayOneShot(clip);
    }
}
