using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item", fileName = "Item_")]
public class Item : ScriptableObject
{
    [Header("Defaults")]
    public string itemName;
    public string category;
    [TextArea(0, 5)] public string itemDescription;
    public Sprite itemIcon;

    [Header("Settings")]
    public ItemParameters parameters;
    public List<BaitAffinityEntry> affinities = new List<BaitAffinityEntry>();

    [System.Serializable]
    public struct ItemParameters
    {
        public float Power; // Quanto que multiplica suas potencias para pegar um humano
        public float Attractiveness; // Quanto maior, diminui o tempo para poder algum humano morder a isca
    }
}