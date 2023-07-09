using UnityEngine;
using TMPro;

public class ToolTip : MonoBehaviour
{
    [Header("ToolTipConfigs")]
    public Vector3 offset;
    public bool isInteractable;
    private bool isActive;

    [HideInInspector] public TMP_Text itemText;
    private ToolTipElement tooltip;

    private void Awake()
    {
        tooltip = GetComponentInChildren<ToolTipElement>(true);
        itemText = GetComponentInChildren<TMP_Text>(true);
    }

    private void Update()
    {
        if (tooltip.gameObject.activeSelf)
        {
            Vector3 toolTipPosition = tooltip.transform.position;
            Vector3 worldPosition = Camera.main.WorldToScreenPoint(transform.position + offset);

            if (!isActive)
            {
                tooltip.transform.position = worldPosition;
                isActive = true;
            }
            else
            {
                tooltip.transform.position = Vector3.Slerp(toolTipPosition, worldPosition, 0.1f);
            }
        }
    }

    public bool SameItemName(string name) => itemText.text == name;

    public void OpenToolTip()
    {
        tooltip.gameObject.SetActive(true);
    }

    public void CloseToolTip()
    {
        tooltip.gameObject.SetActive(false);
        isActive = false;
    }
}