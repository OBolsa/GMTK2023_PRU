using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Fishs", fileName = "Fish")]
public class Fish : ScriptableObject
{
    [Header("Defaults")]
    public string fishName;
    public int value;

    [Header("Settings")]
    public FishParameters parameters;
    public BaitAffinity baitAffinities;

    [System.Serializable]
    public struct FishParameters
    {
        public float Difficulty; // Velocidade do circulo
        public float Resistance; // Quanto que é reduzido do valor quando se acerta
        public float Agressivity; // Quanto que perde quando erra
    }

    [System.Serializable]
    public struct BaitAffinity
    {
        public BaitAffinityType taste;
        public BaitAffinityType fun;
        public BaitAffinityType trendyness;
        public BaitAffinityType technology;
        public BaitAffinityType knowledge;
        public BaitAffinityType value;
    }

    public enum BaitAffinityType
    {
        Null = 0,
        Low = 1,
        Medium = 3,
        High = 7
    }
}