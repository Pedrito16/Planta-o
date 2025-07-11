using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class PlantCollector : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GrowScript growScript;

    

    void Start()
    {
        growScript = GetComponent<GrowScript>();
    }

    void Update()
    {
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(growScript.hasGrown)
        {
            Destroy(gameObject); // Destrói o objeto da planta
        }
    }
}
