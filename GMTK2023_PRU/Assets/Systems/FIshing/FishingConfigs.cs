using GD.MinMaxSlider;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Fish/Configs", fileName = "FishingConfigs_")]
public class FishingConfigs : ScriptableObject
{
    public List<FishingQTE> quickTimeEvents = new List<FishingQTE>();

    [System.Serializable]
    public struct FishingQTE
    {
        [MinMaxSlider(0, 360)] public Vector2 range;
    }
}