using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Menu_Collection : BaseMenu
{
    [Header("Collection")]
    [SerializeField] UiCatchIndex prefabIndex;
    [SerializeField] Transform indexTransform;
    [SerializeField] List<UiCatchIndex> indexes = new List<UiCatchIndex>();

    public override void Init()
    {
        foreach (var item in indexes)
        {
            Destroy(item.gameObject);
        }

        indexes.Clear();

        foreach (var item in GameplayManager.instance.ScriptableManager.allCatches)
        {
            var newIndex = Instantiate(prefabIndex, indexTransform);
            newIndex.Init(this,item);
            indexes.Add(newIndex);
        }
    }

    public override void OpenCloseMenu(bool open)
    {
        base.OpenCloseMenu(open);
        Init();
    }
}
