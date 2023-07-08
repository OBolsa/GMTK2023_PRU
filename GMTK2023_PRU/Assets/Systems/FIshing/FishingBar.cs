using System.Collections;
using System.Collections.Generic;
using UnityEditor.Recorder.FrameCapturer;
using UnityEngine;
using UnityEngine.UI;

public class FishingBar : MonoBehaviour
{
    [Header("Bar Components")]
    public Image fillBar;
    public Image decreaseBar;
    public Transform pointer;
    public Transform pointerMin;
    public Transform pointerMax;

    [Header("Bar Configs")]
    public float barMax;
    public float barStep;
    private float fillAmoutToDecrease;
    private bool doDecrease = false;

    [Header("Debug")]
    public bool canDecrease = false;
    [HideInInspector]public float decreasePerTime;

    private void Start()
    {
        Setup();
    }

    private void Update()
    {
        if(canDecrease)
            DecreaseBar(decreasePerTime * Time.deltaTime);
    }

    public void MovePointer() => pointer.position = Vector3.Lerp(pointer.position, Vector3.Lerp(pointerMin.position, pointerMax.position, barStep / barMax), 0.2f);

    public void IncreaseBar(float amount)
    {
        barStep += amount;
        barStep = barStep > 100 ? 100 : barStep;
        UpdateFillBar();
    }

    public void DecreaseBar(float amount)
    {
        barStep -= amount;
        barStep = barStep < 0 ? 0 : barStep;
        UpdateFillBar();
    }

    private void UpdateFillBar()
    {
        fillBar.fillAmount = barStep / barMax;
        fillAmoutToDecrease = fillBar.fillAmount;

        if (!doDecrease)
        {
            doDecrease = true;
            Invoke(nameof(UpdateDecreaseBar), 0.5f);
        }

        MovePointer();
    }

    private void UpdateDecreaseBar()
    {
        decreaseBar.fillAmount = fillAmoutToDecrease;
        doDecrease = false;
    }

    public void Setup()
    {
        UpdateFillBar();
        UpdateDecreaseBar();
    }
}