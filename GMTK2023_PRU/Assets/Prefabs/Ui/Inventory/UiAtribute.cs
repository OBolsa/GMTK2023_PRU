using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiAtribute : MonoBehaviour
{
    private BaitAffinity affinity;
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private Image fill;
    [field: SerializeField] private Gradient valueGradient;

    //Init tem que receber os parametros da isca e qual é o atributo 
    public void Init(BaitAffinity affinityParam)
    {
        affinity = affinityParam;
        icon.sprite = affinityParam.icon;
        title.text = affinityParam.affinityName;
        fill.color = affinityParam.color;

    }

    public void UpdateValues(BaitAffinityEntry entry)
    {
        if (entry == null)
        {
            fill.fillAmount = 0;
            return;
        }

        switch (entry.typeOfAffinity)
        {
            case BaitAffinityAmount.Low:
                fill.fillAmount = .33f;
                break;
            case BaitAffinityAmount.Medium:
                fill.fillAmount = .66f;
                break;
            case BaitAffinityAmount.High:
                fill.fillAmount = 1;
                break;
        }

        fill.color = affinity.color * valueGradient.Evaluate(fill.fillAmount);
    }

}
