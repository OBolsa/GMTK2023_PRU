using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Menu_Inventory : BaseMenu
{
    [Header("Inventory")]
    [SerializeField] UiCatchIndex prefabIndex;
    [Header("Description")]
    [SerializeField] Image descImage;
    [SerializeField] TextMeshProUGUI descTitle;
    [SerializeField] TextMeshProUGUI descCategory;
    [SerializeField] TextMeshProUGUI descDescription;
    [SerializeField] TextMeshProUGUI descQty;


    public override void Init()
    {
        //instantiate indexes and init them
    }

    public override void OpenCloseMenu(bool open)
    {
        base.OpenCloseMenu(open);
        Init();
    }

    public void UpdateSelectedItem()
    {

    }
}
