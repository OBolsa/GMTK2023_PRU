using UnityEngine;

public class FishingManager : MonoBehaviour
{
    public static FishingManager Instance;

    public float defaultIncreaseAmount = 20f;
    public float defaultDecreaseAmount = 5f;
    [Range(0.001f, 1f)] public float barDecreaseAgressivityFactor = 0.2f;
    public float pointerDefaultSpeed = 100f;
    public float powPointerSpeedValue = 1.15f;

    private void Awake()
    {
        Instance = this;
    }
}