using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiCatchIndex : MonoBehaviour
{
    private Fish associatedCatchable;
    [Header("Components")]
    [SerializeField] private Image catchImage;
    [SerializeField] private TextMeshProUGUI catchQty;
    [SerializeField] private TextMeshProUGUI catchName;
    [SerializeField] private TextMeshProUGUI catchCategory;
    [SerializeField] private TextMeshProUGUI catchDescription;
    [Header("Baits")]
    [SerializeField] private UiAtribute catchAffinityPrefab;
    [SerializeField] private Transform catchAffinityParent;
    [SerializeField] private GameObject favoriteBaitParent;
    [SerializeField] private Image favoriteBaitImage;
    [SerializeField] private GameObject favoriteBaitTransform;
    private List<UiAtribute> uiAffinities = new List<UiAtribute>();
    private Menu_Collection menu;

    //Init tem que receber os parametros da isca e qual é o atributo 
    public void Init(Menu_Collection menuParam, Fish catchable)
    {
        menu = menuParam;
        associatedCatchable = catchable;

        bool available = associatedCatchable.amountCatched > 0;

        catchImage.sprite = associatedCatchable.preyIcon;
        catchImage.color = available ? Color.white: Color.black;
        catchName.text = available ? associatedCatchable.preyName : "Unknown";
        catchCategory.text = available ? associatedCatchable.preyCategory : "???";
        catchDescription.text = available ? associatedCatchable.preyDescription : "Must catch one of these first!";
        catchQty.text = associatedCatchable.amountCatched.ToString();

        favoriteBaitTransform.SetActive(associatedCatchable.favoriteBait);

        if (associatedCatchable.favoriteBait)
            favoriteBaitImage.sprite = associatedCatchable.favoriteBait.itemIcon;

        UpdateAffinities();

    }

    private void UpdateAffinities()
    {

        foreach (var item in uiAffinities)
        {
            Destroy(item.gameObject);
        }

        uiAffinities.Clear();

        foreach (var item in associatedCatchable.baitAffinitiesList)
        {
            var newItem = Instantiate(catchAffinityPrefab, catchAffinityParent);
            newItem.Init(item.affinity);
            newItem.UpdateValues(item);
            uiAffinities.Add(newItem);
        }

    }
}
