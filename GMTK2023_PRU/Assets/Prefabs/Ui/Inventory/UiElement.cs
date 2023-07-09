using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class UiElement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] protected Button button;

    private void Start()
    {
        button.onClick.AddListener(Click);
    }

    protected virtual void Click()
    {

    }

    protected virtual void CursorOver(bool selected)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CursorOver(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        CursorOver(true);
    }
}
