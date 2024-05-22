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

    public void FocusThis(bool state) {
        if (placableHouses[placableHouses.Count -1].nextHouses.Count > 0) {
            CanvasManager.instance.buildingRequestScrollGridPanel.HasFocusedBuildingSlot = state;
        }
        if (CanvasManager.instance.buildingRequestScrollGridPanel.HasFocusedBuildingSlot) {
            for (int i = 0; i < placableHouses[placableHouses.Count -1].nextHouses.Count; i++) {
                CanvasManager.instance.buildingRequestScrollGridPanel.InstantiateBuildRequestUI();
                
                CanvasManager.instance.buildRequestUIs[i].SetVariables(placableHouses[placableHouses.Count -1].nextHouses[i], this);
            }
        }
    }

    public bool TrySpendResources (int woodCost, int stoneCost, int metalCost) {
        if (woodCost <= Resources.instance.woodResource.Amount && stoneCost <= Resources.instance.stoneResource.Amount && metalCost <= Resources.instance.metalResource.Amount) {
            Debug.Log("TRUE?");
            Resources.instance.woodResource.SubtractResource(woodCost);
            Resources.instance.stoneResource.SubtractResource(stoneCost);
            Resources.instance.metalResource.SubtractResource(metalCost);
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

        spawnedHouse.transform.parent = gameObject.transform;
        spawnedHouse.transform.localPosition = Vector3.zero;

        if (placableHouses[placableHouses.Count-1].nextHouses.Count > 0) {
            placableHouses.Add(houseToPlace);
        }
    }

    public void DowngradeHouse() {

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
