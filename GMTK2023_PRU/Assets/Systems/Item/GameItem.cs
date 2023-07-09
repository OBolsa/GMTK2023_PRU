using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItem : DynamicItem, IInteractable
{
    [Header("Config")]
    public Item item;

    [Header("Components")]
    public SpriteRenderer spriteRenderer;
    private Sprite lastSprite;
  
    public void DoInteraction()
    {
        InventoryHolder.Instance.inventory.AddItem(item, 1);
        ItemManager.Instance.ReturnItem(this);
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        UpdateItem();
        ItemManager.Instance.ActiveItem(this);
    }

    private void OnDisable()
    {
        ItemManager.Instance.DisactiveItem(this);
    }

    private void LateUpdate()
    {
        if (!toolTip.SameItemName(item.itemName)) toolTip.itemText.text = item.itemName;
        lastSprite = spriteRenderer.sprite;
    }

    private void OnValidate()
    {
        UpdateItem();
    }

    public void UpdateItem()
    {
        if (lastSprite != item.itemIcon)
        {
            spriteRenderer.sprite = item.itemIcon;
        }
    }
}