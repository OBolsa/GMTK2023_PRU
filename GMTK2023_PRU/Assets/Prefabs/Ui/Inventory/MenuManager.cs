using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    [SerializeField] MenuTab[] tabs = new MenuTab[3];
    [SerializeField] CanvasGroup cgSelf;
    private int currentTabIndex = 0;
    private bool menuOpen;

    private void Awake()
    {
        Init();
        OpenCloseMenu(false);
    }

    public virtual void OpenCloseMenu(bool open)
    {
        cgSelf.DOFade(open ? 1 : 0, .25f).SetUpdate(true);
        cgSelf.interactable = open;
        cgSelf.blocksRaycasts = open;

        if(open)
            SelectTab(currentTabIndex);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            OpenCloseMenu(!menuOpen);
    }

    public void Init()
    {
        for (int i = 0; i < tabs.Length; i++)
        {
            tabs[i].index = i;
            tabs[i].menu.Init();
        }
    }

    public void SelectTab(int index)
    {
        foreach (var item in tabs)
        {
            item.menu.OpenCloseMenu(item.index == index);
            currentTabIndex = index;
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

