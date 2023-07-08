using GD.MinMaxSlider;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.UI;

public class Fishing : MonoBehaviour
{
    public GameObject defaultRadial;
    public Transform pointer;
    public FishingBar bar;
    public FishingConfigs configs;
    private List<GameObject> greens = new List<GameObject>();
    private Vector2[] ranges;
    private int currentRange = 0;
    private bool canDoQuickTimeEvent = true;

    //-- PointerRotation
    [Header("Pointer Configs")]
    public float pointerSpeed;
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
        greens[currentRange].gameObject.SetActive(false); // Desliguei a indica��o visual para mostrar que ele j� acertou esse. No UpdateRange() eu ligo todos de novo.
        Debug.Log("ACERTEI MIZERAVI");
    }

    public void Incorrect()
    {
        Debug.Log("TURURU");
        // Si fufu irm�o. KKKKK K K KK K K K
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
        pointerZRotation += pointerSpeed * Time.deltaTime;
        pointer.rotation = Quaternion.Euler(0f, 0f, -pointerZRotation);
    }


    [ContextMenu("Setup")]
    public void Setup()
    {
        CleanGreens();

        for (int i = 0; i < configs.quickTimeEvents.Count; i++)
        {
            float min = configs.quickTimeEvents[i].range.x;
            float max = configs.quickTimeEvents[i].range.y;

            GameObject obj = Instantiate(defaultRadial, transform);

            obj.GetComponent<Image>().fillAmount = (max - min) / 360f;

            obj.transform.rotation = Quaternion.Euler(0f, 0f, 180 - min);
            greens.Add(obj);
        }

        SetupRanges();
    }
    private void SetupRanges()
    {
        ranges = new Vector2[configs.quickTimeEvents.Count];

        for (int i = 0; i < ranges.Length; i++)
        {
            ranges[i] = configs.quickTimeEvents[i].range;
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