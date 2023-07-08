using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BaseMenu : MonoBehaviour
{
    [SerializeField] private CanvasGroup cgSelf;

    
    public virtual void Init()
    {

    }

    public virtual void OpenCloseMenu(bool open)
    {
        cgSelf.DOFade(open ? 1 : 0, .25f).SetUpdate(true);
        cgSelf.interactable = open;
        cgSelf.blocksRaycasts = open;
    }
}
