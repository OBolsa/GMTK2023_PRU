using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class UiElement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] protected Button button;

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }

    private void Init()
    {

    }
    /*
    private void Selection(bool selected)
    {
        cgSelection.DOFade(selected ? 1 : 0, .25f);
    }
    */
}
