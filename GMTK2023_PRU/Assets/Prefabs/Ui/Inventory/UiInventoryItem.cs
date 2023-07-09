using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using TMPro;

public class UiInventoryItem : UiElement
{
    Menu_Inventory menuInventory;
    [SerializeField] Item associatedItem;
    [SerializeField] TextMeshProUGUI textQty;

    public void Init(Menu_Inventory menu, Item item)
    {
        menuInventory = menu;
        associatedItem = item;
    }
    protected override void Click()
    {
        base.Click();
        menuInventory.UpdateSelectedItem(associatedItem);
    }
}
