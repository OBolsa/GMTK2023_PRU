using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHolder : MonoBehaviour
{
    public Inventory inventory;

    private void Update()
    {
        GameItem nearbyItem = NearbyToolTips.nearbyToolTip as GameItem;

        if (nearbyItem != null && Input.GetKeyDown(KeyCode.E))
        {
            inventory.AddItem(nearbyItem.item);
            ItemManager.Instance.ReturnItem(nearbyItem);
            nearbyItem.gameObject.SetActive(false);
        }
    }
}