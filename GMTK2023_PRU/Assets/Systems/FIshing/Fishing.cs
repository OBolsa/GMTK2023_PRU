using GD.MinMaxSlider;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fishing : MonoBehaviour
{
    public GameObject defaultRadial;
    public Transform pointer;
    public FishingBar bar;
    public Fish preyFishing;
    public Item baitUsed;
    private List<GameObject> greens = new List<GameObject>();
    private Vector2[] ranges;
    private int currentRange = 0;
    private bool canDoQuickTimeEvent = true;

    //-- PointerRotation
    [Header("Pointer Configs")]
    public float pointerBaseSpeed;
    private float pointerZRotation = 0;
    private float CurrentRotation() => Mathf.Abs(360 - pointer.localEulerAngles.z);

    private void OnEnable()
    {
        Setup();
    }

    private void Update()
    {
        DoPointerRotation();
        UpdateRange();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckQuickTimeEvent();
        }
    }

    public void Correct()
    {
        float amountToIncrease = FishingManager.Instance.defaultIncreaseAmount - (preyFishing.parameters.Resistance / 100) * FishingManager.Instance.defaultIncreaseAmount;

        bar.IncreaseBar(amountToIncrease);
        greens[currentRange].gameObject.SetActive(false); // Desliguei a indicação visual para mostrar que ele já acertou esse. No UpdateRange() eu ligo todos de novo.

        Debug.Log("ACERTEI MIZERAVI");
    }

    public void Incorrect()
    {
        float amountToDecrease = FishingManager.Instance.defaultIncreaseAmount + (preyFishing.parameters.Agressivity);

        bar.DecreaseBar(amountToDecrease);

        Debug.Log("TURURU");
    }

    private void CheckQuickTimeEvent()
    {
        if (IsQuickTimeEventCorrect() && canDoQuickTimeEvent)
        {
            canDoQuickTimeEvent = false;
            Correct();
        }
        else
        {
            Incorrect();
        }
    }

    private void UpdateRange()
    {
        for (int i = 0; i < ranges.Length; i++)
        {
            if (IsInRange(CurrentRotation(), ranges[i]))
            {
                currentRange = i;
                return;
            }
        }

        currentRange = -1;
        canDoQuickTimeEvent = true;
        greens.ForEach(g => g.SetActive(true));
    }

    private bool IsQuickTimeEventCorrect()
    {
        if (currentRange < 0)
            return false;
        
        greens[currentRange].SetActive(false);
        return true;
    }

    private bool IsInRange(float value, Vector2 range) => value >= range.x && value < range.y;

    private void DoPointerRotation()
    {
        float speed = FishingManager.Instance.pointerDefaultSpeed + Mathf.Pow(preyFishing.parameters.Difficulty, FishingManager.Instance.powPointerSpeedValue);

        pointerZRotation += speed * Time.deltaTime;
        pointer.rotation = Quaternion.Euler(0f, 0f, -pointerZRotation);
    }

    [ContextMenu("Setup")]
    public void Setup()
    {
        CleanGreens();

        for (int i = 0; i < preyFishing.quickTimeEvent.Events.Count; i++)
        {
            float min = preyFishing.quickTimeEvent.Events[i].range.x;
            float max = preyFishing.quickTimeEvent.Events[i].range.y;

            GameObject obj = Instantiate(defaultRadial, transform);

            obj.GetComponent<Image>().fillAmount = (max - min) / 360f;

            obj.transform.rotation = Quaternion.Euler(0f, 0f, 180 - min);
            greens.Add(obj);
        }

        SetupRanges();
        bar.decreasePerTime = preyFishing.parameters.Agressivity * FishingManager.Instance.barDecreaseAgressivityFactor;
        bar.canDecrease = true;
    }

    private void SetupRanges()
    {
        ranges = new Vector2[preyFishing.quickTimeEvent.Events.Count];

        for (int i = 0; i < ranges.Length; i++)
        {
            ranges[i] = preyFishing.quickTimeEvent.Events[i].range;
        }
    }

    [ContextMenu("Clean Greens")]
    private void CleanGreens()
    {
        for (int i = 0; i < greens.Count; i++)
        {
            DestroyImmediate(greens[i]);
        }

        greens.Clear();
    }
}