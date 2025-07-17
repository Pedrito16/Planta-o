using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
public class ShopSelectMenu : MonoBehaviour
{
    [SerializeField] SelectEffect[] items;
    public bool isSelecting;
    public SelectEffect currentActive;
    public static ShopSelectMenu instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        items = GetComponentsInChildren<SelectEffect>();
        Lock();
    }
    void Lock()
    {
        for (int i = 0; i < items.Length; i++)
        {
            SelectEffect item = items[i];
            if (i == 0)
            {
                item.locked = false;
                i += 1;
                items[i].Lock(true);
            }
            else
            {
                item.Lock(true);
                item.selectedBackground.gameObject.SetActive(false);
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
    }
    void Update()
    {
        
    }
}
