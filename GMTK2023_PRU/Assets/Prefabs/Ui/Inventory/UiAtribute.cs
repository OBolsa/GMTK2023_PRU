using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiAtribute : MonoBehaviour
{
    public BaitAffinity affinity;
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

        float ratio = 0;
        switch (entry.typeOfAffinity)
        {
            case BaitAffinityAmount.Low:
                ratio = .33f;
                break;
            case BaitAffinityAmount.Medium:
                ratio = .66f;
                break;
            case BaitAffinityAmount.High:
                ratio = 1;
                break;
        }
        fill.fillAmount = ratio;

        fill.color = affinity.color * valueGradient.Evaluate(ratio);
    }

}
