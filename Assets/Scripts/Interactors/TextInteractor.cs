using UnityEngine;

public class TextInteractor : InteractorMonobehaviour
{
    [SerializeField] private string title;
    [SerializeField] [TextArea] private string content;
    [SerializeField] private CanvasTextManager textPanel;

    private void OnEnable()
    {
        textPanel.gameObject.SetActive(false);
    }
    
    public void UpdateText()
    {
        textPanel.UpdateText(title, content);
    }

    protected override void TriggerInteraction(bool isEnteringTrigger)
    {
        textPanel.gameObject.SetActive(isEnteringTrigger);
    }
}
