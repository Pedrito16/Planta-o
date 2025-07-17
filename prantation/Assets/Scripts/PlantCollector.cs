using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class PlantCollector : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GrowScript growScript;

    

    void Start()
    {
        growScript = GetComponent<GrowScript>();
    }

    void Update()
    {

    }   
    public void OnPointerDown(PointerEventData eventData)
    {
        if (growScript.hasGrown)
        {
            Destroy(gameObject); // Destrói o objeto da planta
        }
    }
}
