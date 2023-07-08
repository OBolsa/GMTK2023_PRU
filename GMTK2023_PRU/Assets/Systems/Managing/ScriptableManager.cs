using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableManager")]
public class ScriptableManager : ScriptableObject
{
    public Inventory playerInventory;
    public Item[] allItems= new Item[0];
    public Fish[] allCatches = new Fish[0];
}
