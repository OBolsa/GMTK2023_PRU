using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NearbySpots : MonoBehaviour
{
    private List<DynamicItem> closeToolTips = new List<DynamicItem>();
    public static DynamicItem nearbyFishingSpot;

    private void Update()
    {
        if (closeToolTips.Count > 0)
        {
            nearbyFishingSpot = closeToolTips.OrderBy(tip => Vector3.Distance(tip.transform.position, transform.position)).FirstOrDefault();

            closeToolTips.ForEach(t => t.toolTip.CloseToolTip());

            HUD.Instance.InteractionBox.SetActive(nearbyFishingSpot.toolTip.isInteractable);
            nearbyFishingSpot.toolTip.OpenToolTip();

            if (Input.GetKeyDown(KeyCode.E))
            {
                IInteractable interactable = nearbyFishingSpot as IInteractable;

                if (interactable != null)
                {
                    interactable.DoInteraction();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<DynamicItem>(out var item))
        {
            FishingSpot spot = item as FishingSpot;
            
            if(spot != null)
            {
                closeToolTips.Add(item);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<DynamicItem>(out var item))
        {
            FishingSpot spot = item as FishingSpot;

            if (spot != null)
            {
                closeToolTips.Remove(item);
                HUD.Instance.InteractionBox.SetActive(false);
                item.toolTip.CloseToolTip();
            }
        }
    }
}
