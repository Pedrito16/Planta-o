using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class OnSelectPlant : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI costText;
    public Button buyButton;
    public static OnSelectPlant instance;
    private void Awake()
    {
        instance = this;
        nameText.gameObject.SetActive(false);
        costText.gameObject.SetActive(false);
        buyButton.gameObject.SetActive(false);
    }
    void Start()
    {
        buyButton.onClick.AddListener(CheckIfCanBuy);
    }
    void CheckIfCanBuy()
    {
        SelectEffect currentActive = ShopSelectMenu.instance.currentActive;
        if (currentActive == null) return;
        int money = PlayerInfos.instance.money;
        if (money >= currentActive.plantInfo.value)
        {
            PlayerInfos.instance.SubtractMoney(currentActive.plantInfo.value);
            PlantSeeds.instance.Plant(currentActive.plantInfo);
        }
    }
    public void OnSelect(string plantName, int cost)
    {
        nameText.gameObject.SetActive(true);
        costText.gameObject.SetActive(true);

        nameText.text = plantName;
        costText.text = "Custo: " + cost.ToString();
    }
    public void SetActive(bool activeOrDeactive)
    {
        buyButton.gameObject.SetActive(activeOrDeactive);
        nameText.gameObject.SetActive(activeOrDeactive);
        costText.gameObject.SetActive(activeOrDeactive);
    }
    void Update()
    {
        
    }
}
