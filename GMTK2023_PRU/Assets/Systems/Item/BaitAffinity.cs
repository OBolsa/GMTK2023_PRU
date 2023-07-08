using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Bait Affinity")]
public class BaitAffinity : ScriptableObject
{
    public string affinityName;
    public Color color;
    public Sprite icon;
}

public enum BaitAffinityAmount
{
    Low = 1,
    Medium = 3,
    High = 7
}