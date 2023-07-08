using UnityEngine;

public class HUD : MonoBehaviour
{
    public static HUD Instance;

    public GameObject InteractionBox;

    private void Awake()
    {
        Instance = this;
    }
}