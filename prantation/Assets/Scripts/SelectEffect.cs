using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField] GameObject selectEffect;
    [SerializeField] Image icon;
    public PlantInfo plantInfo;
    public Image selectedBackground;
    public Image cadeado;
    public bool locked = true;
    void Awake()
    {

    }
    void Start()
    {
        selectEffect.SetActive(false);
        selectedBackground.enabled = false;
        cadeado.enabled = false;
    }
    public void Lock(bool willLock)
    {
        if (willLock)
        {
            icon.color = Color.gray;
            cadeado.enabled = true;
            locked = true;
        }
        else
        {
            icon.color = Color.white;
            cadeado.enabled = false;
            locked = false;
        }
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if(locked) return;
        ShopSelectMenu shopSelect = ShopSelectMenu.instance;
        //no if(sozinho) debaixo, colocar um método que desativa o atual selecionado
        if (shopSelect.currentActive == this)
        {
            selectedBackground.enabled = !selectedBackground.enabled;
            shopSelect.isSelecting = !selectedBackground.enabled;
            OnSelectPlant.instance.SetActive(selectedBackground.enabled);
        }

        else if (shopSelect.currentActive == null) shopSelect.SelectOther(this);

        else shopSelect.SelectOther(this); 
    }
    #region OnPointer
    public void OnPointerEnter(PointerEventData eventData)
    {
        selectEffect.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        selectEffect.SetActive(false);
    }
    #endregion
}
