using UnityEngine;
using System.Collections.Generic;
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
