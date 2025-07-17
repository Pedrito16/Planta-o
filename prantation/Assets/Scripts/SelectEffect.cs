using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField] GameObject selectEffect;
    public Image selectedBackground;
    void Start()
    {
        selectEffect.SetActive(false);
        selectedBackground.enabled = false;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        selectEffect.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        selectEffect.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ShopSelectMenu shopSelect = ShopSelectMenu.instance;
        //no if(sozinho) debaixo, colocar um método que desativa o atual selecionado
        if (shopSelect.currentActive == this) selectedBackground.enabled = !selectedBackground.enabled;

        else if (shopSelect.currentActive == null) shopSelect.SelectOther(this);

        else shopSelect.SelectOther(this); 
    }
}
