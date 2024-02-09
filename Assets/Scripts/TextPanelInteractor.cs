using TMPro;
using UnityEngine;

public class TextPanelInteractor : MonoBehaviour
{
    [Tooltip("Place your model prefab here, and then click on the generate button!")] 
    public GameObject Model;
    
    [SerializeField]
    [Range(1, 40)] private float range = 5;
    [SerializeField] private string title;
    [SerializeField] [TextArea]private string content;
    [SerializeField] private CanvasTextManager textPanel;

    private SphereCollider sphereCollider;

    private void OnEnable() 
    {
        sphereCollider = GetComponent<SphereCollider>();
        textPanel.gameObject.SetActive(false);
        UpdateText();
    }

    public void UpdateText()
    {
        textPanel.UpdateText(title, content);
    }

    private void OnValidate()
    {
        if (sphereCollider == null) sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius = range;
    }

    private void OnTriggerEnter(Collider other)
    {
        textPanel.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        textPanel.gameObject.SetActive(false);
    }
}
