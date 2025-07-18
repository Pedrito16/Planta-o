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
            ShopSelectMenu shopSelectMenu = ShopSelectMenu.instance;
            if (shopSelectMenu.nextToUnlock.plantInfo.cropTypeToUnlock == growScript.info)
                shopSelectMenu.amountOfCropsToUnlock -= 1;
            PlantSeeds.instance.plantQuantity -= 1;
            PlayerInfos.instance.AddMoney(growScript.info.value);
            Destroy(gameObject); // Destrói o objeto da planta
        }
    }
}
