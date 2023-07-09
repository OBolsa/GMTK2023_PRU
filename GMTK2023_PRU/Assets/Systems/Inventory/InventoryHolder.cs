using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHolder : MonoBehaviour
{
    public static InventoryHolder Instance;
    public Inventory inventory;

    private void Awake()
    {
        Instance = this;
    }
}