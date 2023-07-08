using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using TMPro;

public class UiShopSellable : UiElement
{
    [Header("Sellable")]
    Menu_Shop menuShop;
    [SerializeField] Fish associatedCatch;
    [SerializeField] TextMeshProUGUI textQty;
    [SerializeField] Image catchImage;


    public void Init(Menu_Shop shop, Fish sellable)
    {
        menuShop = shop;
        associatedCatch = sellable;
        textQty.text = sellable.amountCurrent.ToString();
        catchImage.sprite = sellable.preyIcon;
    }

    protected override void Click()
    {
        base.Click();
        menuShop.SellSellable(associatedCatch);
    }

    protected override void CursorOver(bool selected)
    {
        base.CursorOver(selected);
        if(selected)
            menuShop.CursorOverSellable(associatedCatch);
        else
            menuShop.CursorOverSellable(null);
    }

}
