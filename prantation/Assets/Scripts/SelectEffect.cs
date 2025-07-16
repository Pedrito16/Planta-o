using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField] GameObject selectEffect;
    [SerializeField] Image selectedEffect;
    void Start()
    {
        selectEffect.SetActive(false);
        selectedEffect.enabled = false;
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
        selectedEffect.enabled = !selectedEffect.enabled;
    }
}
