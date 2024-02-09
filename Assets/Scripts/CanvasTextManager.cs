using TMPro;
using UnityEngine;

public class CanvasTextManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI content;
    
    public void UpdateText(string titleText, string contentText)
    {
        title.text = titleText;
        content.text = contentText;
    }
}
