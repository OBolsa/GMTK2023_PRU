using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System;

public class Menu_Inventory : BaseMenu
{
    [Header("Inventory")]
    [SerializeField] UiInventoryItem prefabItem;
    [SerializeField] Transform itemTransform;
    [Header("Description")]
    [SerializeField] RectTransform rectDescription;
    [SerializeField] Image descImage;
    [SerializeField] TextMeshProUGUI descTitle;
    [SerializeField] TextMeshProUGUI descCategory;
    [SerializeField] TextMeshProUGUI descDescription;
    [SerializeField] TextMeshProUGUI descQty;
    List<UiInventoryItem> uiItems = new List<UiInventoryItem>();
    [Header("Bait")]
    [SerializeField] TextMeshProUGUI textPower;
    [SerializeField] TextMeshProUGUI textAllure;
    [SerializeField] List<UiAtribute> uiAffinities = new List<UiAtribute>();
    [SerializeField] GameObject keyBaitTransform;
    [SerializeField] Image keyBaitTargetImage;
    [SerializeField] TextMeshProUGUI keyBaitTargetName;


    public override void Init()
    {
        for (int i = 0; i < uiAffinities.Count; i++)
        {
            uiAffinities[i].Init(GameplayManager.instance.ScriptableManager.allAffinities[i]);
        }

        UpdateItems();
        UpdateSelectedItem(null);
    }

    public override void OpenCloseMenu(bool open)
    {
        base.OpenCloseMenu(open);
        UpdateItems();
    }

    private void UpdateItems()
    {
        foreach (var item in uiItems)
        {
          //  uiItems.Remove(item);
            Destroy(item.gameObject);
        }

        uiItems.Clear();

        foreach (var item in GameplayManager.instance.ScriptableManager.playerInventory.items)
        {
            var newItem = Instantiate(prefabItem, itemTransform);
            newItem.Init(this, item.itemInSlot);
            uiItems.Add(newItem);
        }
    }

    public void UpdateSelectedItem(Item item)
    {
        if(item == null)
        {
            rectDescription.localScale = Vector3.zero;
            return;
        }

        rectDescription.DOScale(1, .25f).SetEase(Ease.OutBounce).SetUpdate(true);
        UpdateBaseInformation(item);
        UpdateKeyBaitStatus(item);
        UpdateAffinities(item);
    }

    private void UpdateBaseInformation(Item item)
    {
        descImage.sprite = item.itemIcon;
        descTitle.text = item.itemName;
        descCategory.text = item.category;
        descDescription.text = item.itemDescription;
        descQty.text = GameplayManager.instance.ScriptableManager.playerInventory.items.Find(it => it.itemInSlot == item).quantity.ToString();
        textPower.text = item.parameters.Power.ToString();       
        textAllure.text = item.parameters.Attractiveness.ToString();
    }

    private void UpdateKeyBaitStatus(Item item)
    {
        bool show = false;
        Fish endCatchable = null;
        keyBaitTargetImage.sprite = null;

        foreach (var catchable in GameplayManager.instance.ScriptableManager.allCatches)
        {
            if(catchable.favoriteBait == item)
            {
                show = true;
                endCatchable = catchable;
                keyBaitTargetImage.sprite = catchable.preyIcon;
                keyBaitTargetName.text = catchable.amountCatched > 0 ? catchable.preyName : "?????";
                keyBaitTargetImage.color = catchable.amountCatched > 0 ? Color.white : Color.black;
                break;
            }
        }

        keyBaitTransform.SetActive(show);

    }
    private void UpdateAffinities(Item item)
    {
        for (int i = 0; i < uiAffinities.Count; i++)
        {
            BaitAffinityEntry affinity = item.affinities.Find(a => a.affinity == uiAffinities[i].affinity);
            /*
            if(affinity != null)
                Debug.Log(affinity.affinity);
            else
                Debug.Log("No affinity for" + uiAffinities[i].affinity);
            */
            uiAffinities[i].UpdateValues(affinity);

        }
    }
}
