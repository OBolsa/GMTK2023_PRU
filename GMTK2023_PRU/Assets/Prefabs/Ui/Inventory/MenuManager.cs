using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    [SerializeField] MenuTab[] tabs = new MenuTab[3];

    public void Init()
    {
        for (int i = 0; i < tabs.Length; i++)
        {
            tabs[i].index = i;
        }
    }

    public void SelectTab(int index)
    {
        foreach (var item in tabs)
        {
            item.menu.OpenCloseMenu(item.index == index);
        }
    }
}

[System.Serializable]
public class MenuTab
{
    [HideInInspector] public int index;
    [SerializeField] public Toggle toggle;
    [SerializeField] public BaseMenu menu;

}

