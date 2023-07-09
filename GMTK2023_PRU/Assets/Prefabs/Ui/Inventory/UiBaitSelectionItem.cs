using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using TMPro;

public class UiBaitSelectionItem: UiElement
{
    [Header("Bait Item")]
    BaitSelection menuSelection;
    [SerializeField] Item associatedItem;
    [SerializeField] Image itemImage;
    [SerializeField] TextMeshProUGUI textQty;

    [ContextMenu("Init")]
    public void Init(BaitSelection menu, Item item)
    {
        menuSelection = menu;
        associatedItem = item;
        itemImage.sprite = item.itemIcon;
        textQty.text = GameplayManager.instance.ScriptableManager.playerInventory.items.Find(it => it.itemInSlot == item).quantity.ToString();
    }

    protected override void Click()
    {
        base.Click();
        menuSelection.SelectBait(associatedItem);
    }
}
