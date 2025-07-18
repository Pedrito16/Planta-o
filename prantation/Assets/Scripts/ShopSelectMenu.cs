using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class ShopSelectMenu : MonoBehaviour
{
    [SerializeField] SelectEffect[] items;
    public SelectEffect nextToUnlock;
    public int amountOfCropsToUnlock;
    public bool isSelecting;
    public SelectEffect currentActive;
    int nextToUnlockNumber;
    public static ShopSelectMenu instance;
    
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        nextToUnlockNumber = 1;
        items = GetComponentsInChildren<SelectEffect>();
        nextToUnlock = items[nextToUnlockNumber];
        amountOfCropsToUnlock = nextToUnlock.plantInfo.cropsUntilUnlock;
        Lock(1);
    }
    void Lock(int ativarProximo)
    {
        if (ativarProximo > items.Length) return;
        for (int i = 0; i < items.Length; i++)
        {
            if(i == ativarProximo - 1)
            {
                print("Desbloqueando");
                items[i].gameObject.SetActive(true);
                items[i].Lock(false);
            }
            else if(i == ativarProximo)
            {
                items[i].gameObject.SetActive(true);
                items[i].Lock(true);
            }
            else if (i > ativarProximo)
            {
                items[i].gameObject.SetActive(false);
            }
        }
    }
    public void SelectOther(SelectEffect selectNext)
    {
        if (currentActive == null) currentActive = selectNext;
        else if(selectNext != currentActive)

        currentActive.selectedBackground.enabled = false;
        selectNext.selectedBackground.enabled = true;

        currentActive = selectNext;

        OnSelectPlant.instance.OnSelect(selectNext.plantInfo.Name, selectNext.plantInfo.value); //mostra nome e custo
    }
    void Update()
    {
        if (nextToUnlockNumber > items.Length - 1)
        {
            return;
        }
        if (amountOfCropsToUnlock <= 0)
        {
            nextToUnlockNumber = Mathf.Clamp(nextToUnlockNumber + 1, 0, items.Length);
            Lock(nextToUnlockNumber);
            print(nextToUnlockNumber);
            if(nextToUnlockNumber < items.Length)
            nextToUnlock = items[nextToUnlockNumber]; //se for usar isso aqui, arrumar e deixar o codigo escalavel
            amountOfCropsToUnlock = items[nextToUnlockNumber].plantInfo.cropsUntilUnlock;
        }
    }
}
