using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingSpotArea : MonoBehaviour
{
    public List<Fish> possibleFishsInThisArea = new List<Fish>();
    public List<FishingSpot> mySpots = new List<FishingSpot>();
    public Floater myFloater;

    public Transform minPosition;
    public Transform maxPosition;

    public int minSpots;
    public int maxSpots;

    public GameObject fishingSpotPrefab;

    private void OnEnable()
    {
        SortSpots();
    }

    private void OnDisable()
    {
        DeleteSpots();
    }

    [ContextMenu("Delete Spots")]
    private void DeleteSpots()
    {
        for (int i = mySpots.Count - 1; i >= 0; i--)
        {
            mySpots[i].DeleteSpot();
        }
    }

    [ContextMenu("Sort Spots")]
    private void SortSpots()
    {
        DeleteSpots();

        int spawnedSpots = Random.Range(minSpots, maxSpots);

        while (spawnedSpots > 0)
        {
            float positionSort = Random.Range(0f, 1f);

            GameObject spotObj = Instantiate(fishingSpotPrefab, Vector3.Lerp(minPosition.position, maxPosition.position, positionSort), Quaternion.identity);
            spotObj.transform.parent = transform;

            FishingSpot spot = spotObj.GetComponent<FishingSpot>();
            spot.FillPossibleCatches(possibleFishsInThisArea);
            spot.myArea = this;

            mySpots.Add(spot);

            spawnedSpots--;
        }
    }
}