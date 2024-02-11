using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class InteractorMonobehaviour : MonoBehaviour
{
    [Tooltip("Place your model prefab here, and then click on the generate button!")] 
    public GameObject Model;
    
    [SerializeField]
    [Range(1, 40)] private float triggerRange = 5;

    private SphereCollider sphereCollider;
    
    protected virtual void TriggerInteraction(bool isEnteringTrigger){}

    private void OnEnable()
    {
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
    }

    private void SetRange(float range)
    {
        if (sphereCollider == null)
        {
            sphereCollider = GetComponent<SphereCollider>();
        }
        sphereCollider.radius = range;
    }
    
    private void OnValidate()
    {
        SetRange(triggerRange);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        TriggerInteraction(true);
    }

    private void OnTriggerExit(Collider other)
    {
        TriggerInteraction(false);
    }

}
