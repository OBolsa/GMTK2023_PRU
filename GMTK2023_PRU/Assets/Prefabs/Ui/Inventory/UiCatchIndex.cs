using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiCatchIndex : MonoBehaviour
{
    [SerializeField] private Image catchImage;
    [SerializeField] private TextMeshProUGUI catchQty;
    [SerializeField] private TextMeshProUGUI catchName;
    [SerializeField] private TextMeshProUGUI catchCategory;
    [SerializeField] private TextMeshProUGUI catchDescription;
    [SerializeField] private UiAtribute catchAffinityPrefab;
    [SerializeField] private Transform catchAffinityParent;
    [SerializeField] private GameObject favoriteBaitParent;
    [SerializeField] private Image favoriteBaitImage;

    //Init tem que receber os parametros da isca e qual é o atributo 
    public void Init()
    {

    }
}
