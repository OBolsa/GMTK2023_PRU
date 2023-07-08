using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiAtribute : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private Image fill;
    [field: SerializeField] private Gradient valueGradient;

    //Init tem que receber os parametros da isca e qual é o atributo 
    public void Init()
    {

    }
}
