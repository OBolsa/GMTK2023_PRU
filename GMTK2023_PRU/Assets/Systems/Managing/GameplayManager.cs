using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;
    public ScriptableManager ScriptableManager;
    public BaitSelection BaitSelection;

    private void Awake()
    {
        instance = this;
    }
}
