using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private static SoundManager _instance;
    
    public static SoundManager Instance
    {
        get
        {
            if (_instance != null) return _instance;
            _instance = FindObjectOfType<SoundManager>();
            if (_instance != null) return _instance;
            GameObject singletonObject = new(nameof(SoundManager));
            _instance = singletonObject.AddComponent<SoundManager>();
            DontDestroyOnLoad(singletonObject);
            return _instance;
        }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
