using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSlot : MonoBehaviour
{
    
    public List<HouseUpgradeInfo> placableHouses;

    private HouseUpgradeInfo currentlyPlacedHouseUpgradeInfo;
    private GameObject spawnedHouse;
        
    public void SpawnNextHouse () {
        if (currentlyPlacedHouseUpgradeInfo == placableHouses[placableHouses.Count-1])
        {
            Debug.Log("Maxed out the upgrades");
            return;
        }

        if (spawnedHouse != null) { 
            Destroy(spawnedHouse);
        }

        spawnedHouse = Instantiate(placableHouses[placableHouses.Count-1].housePrefab);
        currentlyPlacedHouseUpgradeInfo = placableHouses[placableHouses.Count-1];

        spawnedHouse.transform.parent = gameObject.transform;
        spawnedHouse.transform.localPosition = Vector3.zero;

        if (placableHouses[placableHouses.Count-1].nextHouse != null) {
            placableHouses.Add(placableHouses[placableHouses.Count-1].nextHouse);
        }
    }
}
