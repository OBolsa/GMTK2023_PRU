using UnityEngine;
using TMPro;

public class ToolTip : MonoBehaviour
{
    [Header("ToolTipConfigs")]
    public Vector3 offset;
    public bool isInteractable;
    private bool isActive;
    public bool canShowTooltip = true;

    public CanvasGroup canvas;
    public ToolTipElement tooltipElements;
    public TMP_Text itemText;

    private void Update()
    {
        if (tooltipElements.gameObject.activeSelf)
        {
            Vector3 toolTipPosition = tooltipElements.transform.position;
            Vector3 worldPosition = Camera.main.WorldToScreenPoint(transform.position + offset);

            if (!isActive)
            {
                tooltipElements.transform.position = worldPosition;
                isActive = true;
            }
            else
            {
                tooltipElements.transform.position = Vector3.Slerp(toolTipPosition, worldPosition, 0.1f);
            }
        }
    }

    public bool SameItemName(string name) => itemText.text == name;

    public void OpenToolTip()
    {
        if (canShowTooltip)
        {
            canvas.alpha = 1;
        }
        else
            CloseToolTip();
    }

    public void CloseToolTip()
    {
        canvas.alpha = 0;
        isActive = false;
    }
}