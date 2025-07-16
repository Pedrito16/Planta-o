using UnityEngine;
using System.Collections.Generic;
public class ShopSelectMenu : MonoBehaviour
{
    [SerializeField] SelectEffect[] items;
    void Start()
    {
        items = GetComponentsInChildren<SelectEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
