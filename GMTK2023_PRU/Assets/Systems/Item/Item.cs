using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item", fileName = "Item_")]
public class Item : ScriptableObject
{
    [Header("Defaults")]
    public string itemName;
    public Sprite itemSprite;

    [Header("Settings")]
    public ItemParameters parameters;
    public Fish.BaitAffinity affinities;

    [System.Serializable]
    public struct ItemParameters
    {
        public float Power; // Quanto que multiplica suas potencias para pegar um humano
        public float Attractiveness; // Quanto maior, diminui o tempo para poder algum humano morder a isca
    }
}