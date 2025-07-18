using UnityEngine;
using TMPro;
public class PlayerInfos : MonoBehaviour
{
    public int money;
    [SerializeField] TextMeshProUGUI moneyText;
    public static PlayerInfos instance;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        moneyText.text = "Dinheiro: " + money.ToString();
    }
    public void AddMoney(int quantity)
    {
        money += quantity;
        moneyText.text = "Dinheiro: " + money.ToString();
    }
    void Update()
    {
        
    }
}
