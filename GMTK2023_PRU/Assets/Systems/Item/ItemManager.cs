using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;
    public List<GameItem> activeItems = new List<GameItem>();
    public List<GameItem> inactiveItems = new List<GameItem>();

    public void ActiveItem(GameItem item)
    {
        activeItems.Add(item);
        inactiveItems.Remove(item);
    }

    public void DisactiveItem(GameItem item)
    {
        activeItems.Remove(item);
        inactiveItems.Add(item);
    }

    public void ReturnItem(GameItem item) => activeItems.Find(a => a == item).transform.parent = transform;

    public GameItem GetItem(Item item)
    {
        GameItem gameItem = inactiveItems.FirstOrDefault();
        gameItem.item = item;
        return gameItem;
    }

    private void Awake()
    {
        Instance = this;
    }
}