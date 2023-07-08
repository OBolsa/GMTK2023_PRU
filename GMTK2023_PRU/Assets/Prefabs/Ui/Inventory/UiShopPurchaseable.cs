using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using TMPro;

public class UiShopPurchaseable : UiElement
{
    [Header("Purchaseable")]
    Menu_Shop menuShop;
    [SerializeField] float cost;
    [SerializeField] TextMeshProUGUI textCost;

    public void Init(Menu_Shop shop)
    {
        menuShop = shop;
        textCost.text = cost.ToString();
    }

    protected override void Click()
    {
        base.Click();
        menuShop.AttemptPurchase(cost);
    }

    protected override void CursorOver(bool selected)
    {
        base.CursorOver(selected);

        if(selected)
            menuShop.CursorOverPurchaseable(cost);
        else
            menuShop.CursorOverPurchaseable(0);
    }

}
