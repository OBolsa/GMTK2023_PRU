using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class UiElement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] protected Button button;

    private void Start()
    {
        button.onClick.AddListener(Click);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        CursorOver(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        CursorOver(false);
    }

    protected virtual void Click()
    {

    }

    protected virtual void CursorOver(bool selected)
    {
    }
}
