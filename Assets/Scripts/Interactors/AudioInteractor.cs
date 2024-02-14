using UnityEngine;

public class AudioInteractor : InteractorMonobehaviour
{
    [SerializeField] private AudioClip audioClip;
    
    protected override void TriggerInteraction(bool isEnteringTrigger)
    {
        if (!isEnteringTrigger) return;
        SoundManager.Instance.PlaySound(audioClip);
    }
}
