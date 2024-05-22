using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSlot : MonoBehaviour
{
    
    public List<HouseUpgradeInfo> placableHouses;

    private HouseUpgradeInfo currentlyPlacedHouseUpgradeInfo;
    private GameObject spawnedHouse;

    public void FocusThis(bool state) {

        for (int i = 0; i < CanvasManager.instance.buildRequestUIs.Count && i < placableHouses[placableHouses.Count -1].nextHouses.Count; i++) {
            CanvasManager.instance.buildRequestUIs[i].FocusedBuildingSlot = state;
            CanvasManager.instance.buildRequestUIs[i].SetVariables(placableHouses[placableHouses.Count -1].nextHouses[i], this);
        }
    }

    public bool TrySpendResources (int woodCost, int stoneCost, int metalCost) {
        if (woodCost <= Resources.instance.Wood && stoneCost <= Resources.instance.Stone && metalCost <= Resources.instance.Metal) {
            Debug.Log("TRUE?");
            Resources.instance.SubtractWood(woodCost);
            Resources.instance.SubtractStone(stoneCost);
            Resources.instance.SubtractMetal(metalCost);
            return true;
        }
        
        return false;
    }

    public void SpawnNextHouse (HouseUpgradeInfo houseToPlace) {
        Debug.Log(houseToPlace.buildingName + " 1 " + placableHouses[placableHouses.Count-1].buildingName);
        if (placableHouses[placableHouses.Count-1].nextHouses.Count <= 0)
        {
            
            Debug.Log("Maxed out the upgrades");
            return;
        }

        if (spawnedHouse != null) { 
            Destroy(spawnedHouse);
        }

        spawnedHouse = Instantiate(houseToPlace.housePrefab);
        currentlyPlacedHouseUpgradeInfo = houseToPlace;

        spawnedHouse.transform.parent = gameObject.transform;
        spawnedHouse.transform.localPosition = Vector3.zero;

        if (placableHouses[placableHouses.Count-1].nextHouses.Count > 0) {
            placableHouses.Add(houseToPlace);
        }
    }
}
