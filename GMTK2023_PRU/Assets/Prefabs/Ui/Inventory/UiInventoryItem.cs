using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using TMPro;

public class UiInventoryItem : UiElement
{
    [Header("Inventory Item")]
    Menu_Inventory menuInventory;
    [SerializeField] Item associatedItem;
    [SerializeField] Image itemImage;
    [SerializeField] TextMeshProUGUI textQty;

    public void Init(Menu_Inventory menu, Item item)
    {
        menuInventory = menu;
        associatedItem = item;
        itemImage.sprite = item.itemIcon;
        textQty.text = GameplayManager.instance.ScriptableManager.playerInventory.items.Find(it => it.itemInSlot == item).quantity.ToString();
    }
    protected override void Click()
    {
        base.Click();
        menuInventory.UpdateSelectedItem(associatedItem);
    }
}
