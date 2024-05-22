using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSlot : MonoBehaviour
{
    public HouseUpgradeInfo defaultPlacableHouse;
    [HideInInspector]
    public List<HouseUpgradeInfo> placableHouses;

    private GameObject spawnedHouse;

    public void Start() {
        placableHouses.Add(defaultPlacableHouse);
    }

    public bool TrySpendingResources (int woodCost, int stoneCost, int metalCost) {
        if (woodCost <= Resources.instance.woodResource.Amount && stoneCost <= Resources.instance.stoneResource.Amount && metalCost <= Resources.instance.metalResource.Amount) {
            Debug.Log("TRUE?");
            Resources.instance.woodResource.SubtractResource(woodCost);
            Resources.instance.stoneResource.SubtractResource(stoneCost);
            Resources.instance.metalResource.SubtractResource(metalCost);
            return true;
        }
        
        return false;
    }

    public void SpawnNextBuilding (HouseUpgradeInfo houseToPlace) {
        Debug.Log(houseToPlace.buildingName + " 1 " + placableHouses[placableHouses.Count-1].buildingName);
        if (placableHouses[placableHouses.Count-1].nextHouses.Count <= 0)
        {
            Debug.Log("Maxed out the upgrades");
            return;
        }

        SpawnBuilding(houseToPlace);
    }

    public bool CanDowngradeBuilding() {
        if (placableHouses[placableHouses.Count -1] != defaultPlacableHouse && placableHouses[placableHouses.Count -2] != defaultPlacableHouse) {
            return true;
        }

        return false;
    }

    public void SpawnPreviousBuilding() {
        HouseUpgradeInfo houseToPlace = placableHouses[placableHouses.Count -2];
        placableHouses.RemoveRange(placableHouses.Count-2, 2);
        SpawnBuilding(houseToPlace);
    }

    private void SpawnBuilding(HouseUpgradeInfo houseToPlace) {
        if (spawnedHouse != null) { 
            Destroy(spawnedHouse);
        }

        spawnedHouse = Instantiate(houseToPlace.housePrefab);

        spawnedHouse.transform.parent = gameObject.transform;
        spawnedHouse.transform.localPosition = Vector3.zero;

        if (placableHouses[placableHouses.Count-1].nextHouses.Count > 0) {
            placableHouses.Add(houseToPlace);
        }
    }

    public bool CanDestroyBuilding() {
        if (placableHouses.Count > 1) {
            return true;
        }

        return false;
    }

    public void ReturnBuildingSlotToDefault () {
        Destroy(spawnedHouse);
        HouseUpgradeInfo emptyHouseInfo = placableHouses[0];
        placableHouses.Clear();
        placableHouses.Add(emptyHouseInfo);
    }
}
