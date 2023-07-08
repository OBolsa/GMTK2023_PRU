using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class Menu_Shop: BaseMenu
{
    static float currentFood;

    [Header("Shop")]
    [SerializeField] UiCatchIndex prefabIndex;

    [Header("Catch Sale")]
    [SerializeField] UiInventoryItem prefabSellable;
    [SerializeField] Transform sellablesTransform;
    [SerializeField] RectTransform saleValueRect;
    [SerializeField] TextMeshProUGUI saleValueText;
    [SerializeField] GameObject symbolPlus;
    [SerializeField] GameObject symbolMinus;


    public override void Init()
    {
        //instantiate sellables
        UpdateSellables();
    }

    public override void OpenCloseMenu(bool open)
    {
        base.OpenCloseMenu(open);
        Init();
    }

    public void UpdateSellables()
    {

    }
    public void CursorOverItem(bool PLACEHOLDERINEEDTHEITEMFIRST)
    {
        /*
        

         
        */

        if(!PLACEHOLDERINEEDTHEITEMFIRST)
        {
            saleValueRect.DOScale(0, .25f).SetEase(Ease.InBounce).SetUpdate(true);
            return;            
        }

        saleValueRect.localScale = Vector3.zero;
        saleValueRect.DOScale(1, .25f).SetEase(Ease.OutBounce).SetUpdate(true);
    }

    public void SellSellable()
    {
        currentFood += 0;
        saleValueRect.DOScale(0, .25f).SetEase(Ease.InBounce).SetUpdate(true);
        UpdateSellables();
    }
}
