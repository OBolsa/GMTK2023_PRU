using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Fishs", fileName = "Fish")]
public class Fish : ScriptableObject
{
    [Header("Defaults")]
    public string preyName;
    public string preyCategory;
    [TextArea(0, 5)] public string preyDescription;
    public Sprite preyIcon;
    public Item favoriteBait;
    public int amountCatched;
    public int amountCurrent;

    [Header("Settings")]
    public int value;
    public QuickTimeEvent quickTimeEvent;
    public FishParameters parameters;
    public List<BaitAffinityEntry> baitAffinitiesList = new List<BaitAffinityEntry>();

    [System.Serializable]
    public struct FishParameters
    {
        public float Difficulty; // Velocidade do circulo
        public float Resistance; // Quanto que é reduzido do valor quando se acerta
        public float Agressivity; // Quanto que perde quando erra
    }
}

[System.Serializable]
public class BaitAffinityEntry
{
    public BaitAffinity affinity;
    public BaitAffinityAmount typeOfAffinity;

}