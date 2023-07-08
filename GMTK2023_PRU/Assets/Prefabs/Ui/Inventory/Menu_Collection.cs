using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Menu_Collection : BaseMenu
{
    [Header("Collection")]
    [SerializeField] UiCatchIndex prefabIndex;

    public override void Init()
    {
        //instantiate indexes and init them
    }

    public override void OpenCloseMenu(bool open)
    {
        base.OpenCloseMenu(open);
        Init();
    }
}
