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
        moneyText.text = money.ToString();
    }
    public void AddMoney(int quantity)
    {
        money += quantity;
        moneyText.text = money.ToString();
    }
    public void SubtractMoney(int quantity)
    {
        money -= Mathf.Abs(quantity);
        moneyText.text = money.ToString();
    }
    void Update()
    {
        
    }
}
