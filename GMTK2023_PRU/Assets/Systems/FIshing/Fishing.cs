using GD.MinMaxSlider;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fishing : MonoBehaviour
{
    public GameObject defaultRadial;
    public FishingConfigs configs;
    private List<GameObject> greens = new List<GameObject>();

    [ContextMenu("Setup")]
    public void Setup()
    {
        for (int i = 0; i < greens.Count; i++)
        {
            DestroyImmediate(greens[i]);
        }

        greens.Clear();

        for (int i = 0; i < configs.quickTimeEvents.Count; i++)
        {
            float min = configs.quickTimeEvents[i].range.x;
            float max = configs.quickTimeEvents[i].range.y;

            GameObject obj = Instantiate(defaultRadial, transform);

            obj.GetComponent<Image>().fillAmount = (max - min) / 360f;

            obj.transform.rotation = Quaternion.Euler(0f, 0f, 180 - min);
            greens.Add(obj);
        }
    }
}