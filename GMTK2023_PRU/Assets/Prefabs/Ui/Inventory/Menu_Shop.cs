using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using System;

public class Menu_Shop: BaseMenu
{
    static float currentFood;

    [Header("Shop")]

    [Header("Catch Sale")]
    [SerializeField] UiShopSellable prefabSellable;
    [SerializeField] Transform sellablesTransform;
    [SerializeField] TextMeshProUGUI foodValueText;
    [SerializeField] RectTransform saleValueRect;
    [SerializeField] TextMeshProUGUI saleValueText;
    [SerializeField] GameObject symbolPlus;
    [SerializeField] GameObject symbolMinus;
    [SerializeField] List<UiShopPurchaseable> purchaseables = new List<UiShopPurchaseable> ();
    [SerializeField] List<UiShopSellable> sellables = new List<UiShopSellable> ();

    public override void Init()
    {
        //instantiate sellables
        UpdateSellables();
        UpdatePurchaseables();
    }

    public override void OpenCloseMenu(bool open)
    {
        base.OpenCloseMenu(open);
        Init();
    }

    private void UpdatePurchaseables()
    {
        foreach (var item in purchaseables)
        {
            item.Init(this);
        }

    }

    public void UpdateSellables()
    {
        foreach (var item in sellables)
        {
           // sellables.Remove(item);
            Destroy(item.gameObject);
        }

        sellables.Clear();

        foreach (var item in GameplayManager.instance.ScriptableManager.allCatches)
        {
            if (item.amountCurrent <= 0)
                continue;

            var newItem = Instantiate(prefabSellable, sellablesTransform);
            newItem.Init(this, item);
            sellables.Add(newItem);
        }

        foodValueText.text = currentFood.ToString();
    }
    public void CursorOverPurchaseable(float value)
    {
        CursorOverItem(value != 0, value);
    }

    public void CursorOverSellable(Fish sellable)
    {
        if(sellable)
            CursorOverItem(sellable, sellable.value);
        else
            CursorOverItem(false, 0);
    }

    public void CursorOverItem(bool isValid, float value)
    {
        if (!isValid)
            saleValueRect.DOScale(0, .25f).SetEase(Ease.OutBack).SetUpdate(true);
        else
        {
            saleValueRect.localScale = Vector3.zero;
            saleValueRect.DOScale(1, .25f).SetEase(Ease.OutBack).SetUpdate(true);
        }

        symbolPlus.SetActive(value > 0);
        symbolMinus.SetActive(value < 0);
        saleValueText.text = Mathf.Abs(value).ToString();
    }

    public bool AttemptPurchase(float value)
    {
        if (currentFood < value)
        {
            PurchaseFail();
            return false;
        }

        currentFood -= value;
        PurchaseSuccess();
        foodValueText.text = currentFood.ToString();
        return true;
    }
    public void SellSellable(Fish sellable)
    {
        sellable.amountCurrent--;
        currentFood += sellable.value;
        saleValueRect.DOScale(0, .25f).SetEase(Ease.InBounce).SetUpdate(true);
        UpdateSellables();
    }

    private void PurchaseFail()
    {

    }
    private void PurchaseSuccess()
    {

    }
}
