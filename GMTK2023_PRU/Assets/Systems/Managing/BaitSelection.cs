using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class BaitSelection : MonoBehaviour
{
    [SerializeField] Item currentBait;
    private bool menuOpen;
    [SerializeField] RectTransform rectSelf;

    [Header("Current")]
    [SerializeField] GameObject currentBaitParent;
    [SerializeField] Image currentBaitIcon;
    [SerializeField] TextMeshProUGUI currentBaitQty;

    [Header("Inventory")]
    [SerializeField] UiBaitSelectionItem prefabItem;
    [SerializeField] Transform itemTransform;
    List<UiBaitSelectionItem> uiBaitItem = new List<UiBaitSelectionItem>();

    private void Awake()
    {
        MenuOpenClose(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            MenuOpenClose(!menuOpen);
    }

    private void MenuOpenClose(bool open)
    {
        menuOpen = !menuOpen;
        //rectSelf.gameObject.SetActive(open);
        rectSelf.DOScale(open ? 1 : 0, .25f).SetEase(Ease.OutBack).SetUpdate(true);

        if(open)
            UpdateItems();

    }

    private void UpdateItems()
    {
        foreach (var item in uiBaitItem)
        {
            //  uiItems.Remove(item);
            Destroy(item.gameObject);
        }

        uiBaitItem.Clear();

        foreach (var item in GameplayManager.instance.ScriptableManager.playerInventory.items)
        {
            var newItem = Instantiate(prefabItem, itemTransform);
            newItem.Init(this, item.itemInSlot);
            uiBaitItem.Add(newItem);
        }
    }

    public void SelectBait(Item bait)
    {
        currentBaitParent.SetActive(bait);

        if (bait == null)
            return;

        currentBait = bait;
        currentBaitIcon.sprite = bait.itemIcon;
        currentBaitQty.text = GameplayManager.instance.ScriptableManager.playerInventory.items.Find(it => it.itemInSlot == bait).quantity.ToString();
        MenuOpenClose(false);
    }
}
