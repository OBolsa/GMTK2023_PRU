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
    public Image pointer;

    [Header("Bar Configs")]
    public float barMax;
    public float barStep;

    [Header("Values")]
    public float raisePerCorrect;
    public float decreasePerIncorrect;
    public float decreasePerTime
    {
        get
        {
            return decreasePerIncorrect * 0.1f;
        }
        set { }
    }

    private void Update()
    {
        DoDecay(decreasePerTime * Time.deltaTime);
    }

    public void DoDecay(float amount)
    {
        barStep -= amount;
        barStep = barStep < 0 ? 0 : barStep;
        float percentageComplete = barStep / barMax;

        fillBar.fillAmount = percentageComplete;

        float timeToDecrease;
        float fillAmount;

        //if(amount >= 5f)
    }

    public void UpdateDecreaseBar(float fillAmount)
    {
        decreaseBar.fillAmount = fillAmount;
    }

    public void Setup()
    {

    }
}