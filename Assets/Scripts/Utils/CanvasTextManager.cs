using TMPro;
using UnityEngine;

public class CanvasTextManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI content;

    private Camera main;

    private void Awake()
    {
        main = Camera.main;
    }

    public void UpdateText(string titleText, string contentText)
    {
        title.text = titleText;
        content.text = contentText;
    }

    private void Update()
    {
        transform.forward = main.transform.forward;
    }
}
