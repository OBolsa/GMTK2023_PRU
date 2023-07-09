using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NearbyToolTips : MonoBehaviour
{
    private List<DynamicItem> closeToolTips = new List<DynamicItem>();
    public static DynamicItem nearbyToolTip;

    private void Update()
    {
        if (closeToolTips.Count > 0)
        {
            nearbyToolTip = closeToolTips.OrderBy(tip => Vector3.Distance(tip.transform.position, transform.position)).FirstOrDefault();

            closeToolTips.ForEach(t => t.toolTip.CloseToolTip());

            HUD.Instance.InteractionBox.SetActive(nearbyToolTip.toolTip.isInteractable);
            nearbyToolTip.toolTip.OpenToolTip();

            if (Input.GetKeyDown(KeyCode.E))
            {
                IInteractable interactable = nearbyToolTip as IInteractable;

                if(interactable != null)
                {
                    interactable.DoInteraction();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<DynamicItem>(out var item))
        {
            closeToolTips.Add(item);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<DynamicItem>(out var item))
        {
            closeToolTips.Remove(item);
            HUD.Instance.InteractionBox.SetActive(false);
            item.toolTip.CloseToolTip();
        }
    }
}