using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingSpot : DynamicItem, IInteractable
{
    public FishingSpotArea myArea;
    public Item bait;
    public Fish sortedFish;
    private List<Fish> possibleCatches = new List<Fish>();
    private List<WheightedFish> wheightedSortedFishs = new List<WheightedFish>();
    private int listedWheight;
    private bool isAttatched;

    public void DoInteraction()
    {
        if (!isAttatched)
        {
            StartBaitSelection();
        }
        else
        {
            StopBaitSelection();
        }
    }

    private void StartBaitSelection()
    {
        bait = GameplayManager.instance.BaitSelection.currentBait;

        myArea.myFloater.StopFloater();

        toolTip.CloseToolTip();
        toolTip.enabled = false;
        toolTip.canShowTooltip = false;
        isAttatched = true;

        SortCatch();
    }

    private void StopBaitSelection()
    {
        myArea.myFloater.StartFloater();

        toolTip.CloseToolTip();
        toolTip.enabled = true;
        toolTip.canShowTooltip = true;
        isAttatched = false;
    }

    public void DeleteSpot()
    {
        myArea.mySpots.Remove(this);
        DestroyImmediate(gameObject);
    }

    public void FillPossibleCatches(List<Fish> possibleCatches) => this.possibleCatches = possibleCatches;

    [ContextMenu("Simulate Sort")]
    private void SortCatch()
    {
        sortedFish = null;
        CalculateWheight();

        int randomFish = (int)Random.Range(0, listedWheight + 0.999f);

        for (int i = 0; i < wheightedSortedFishs.Count; i++)
        {
            if (randomFish < wheightedSortedFishs[i].wheight)
            {
                sortedFish = possibleCatches[i];
                break;
            }
        }

        if (sortedFish == null)
            Debug.Log("N catou nada");
    }

    private void CalculateWheight()
    {
        listedWheight = 0;
        int baseWheight = 0;
        wheightedSortedFishs.Clear();

        List<Fish> fishs = new List<Fish>();

        foreach (var item in possibleCatches)
        {
            if(item.favoriteBait == null || item.favoriteBait == bait)
                fishs.Add(item);
        }

        BaitAffinityEntry[] baitAffinities = bait.affinities.ToArray();

        for (int fish = 0; fish < fishs.Count; fish++)
        {
            for (int baitAffinity = 0; baitAffinity < baitAffinities.Length; baitAffinity++)
            {
                BaitAffinityEntry fishAffinity = fishs[fish].baitAffinitiesList.Find(a => a.affinity == baitAffinities[baitAffinity].affinity);

                if (fishAffinity == null)
                    continue;

                baseWheight += (int)fishAffinity.typeOfAffinity * (int)baitAffinities[baitAffinity].typeOfAffinity;
            }

            wheightedSortedFishs.Add(new WheightedFish(fishs[fish].name, baseWheight));
        }

        listedWheight = baseWheight;
    }

    [System.Serializable]
    public class WheightedFish
    {
        public string fish;
        public int wheight;

        public WheightedFish(string fish, int wheight)
        {
            this.fish = fish;
            this.wheight = wheight;
        }
    }
}