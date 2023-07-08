using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using TMPro;

public class UiInventoryItem : UiElement
{
    [SerializeField] Menu_Inventory menuInventory;
    [SerializeField] TextMeshProUGUI textQty;

    private void Init(Menu_Inventory menu)
    {
        menuInventory = menu;
        button.onClick.AddListener(SelectItem);
    }

    private void SelectItem()
    {
        menuInventory.UpdateSelectedItem();
    }
}
