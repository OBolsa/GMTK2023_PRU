using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicItem : MonoBehaviour
{
    [HideInInspector] public ToolTip toolTip;

    private void Awake()
    {
        toolTip = GetComponentInChildren<ToolTip>(true);
    }
}