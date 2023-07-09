using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory", fileName = "Inventory_")]
public class Inventory : ScriptableObject
{
    public List<InventorySlot> items = new List<InventorySlot>();
    /*
    private void OnEnable()
    {
        items.Clear();
    }
    */

    public void AddItem(Item item, int quantity)
    {
        InventorySlot slot = items.Find(a => a.itemInSlot == item);

        if (slot != null)
        {
            slot.quantity += quantity;
        }
        else
        {
            items.Add(new InventorySlot(item, quantity));
        }
    }

    public void RemoveItem(Item item, int quantity)
    {
        InventorySlot slot = items.Find(a => a.itemInSlot == item);

        if(slot != null)
        {
            slot.quantity -= quantity;
            if(slot.quantity <= 0)
            {
                items.Remove(slot);
            }
        }
        else
        {
            Debug.Log("Nao tem esse item no inventario");
        }
    }

    [System.Serializable]
    public class InventorySlot
    {
        public Item itemInSlot;
        public int quantity;

        public InventorySlot(Item itemInSlot, int quantity)
        {
            this.itemInSlot = itemInSlot;
            this.quantity = quantity;
        }
    }
}