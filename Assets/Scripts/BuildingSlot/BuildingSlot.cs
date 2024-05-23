using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSlot : MonoBehaviour
{
    [Tooltip("This is a reference to the default HouseUpgradeInfo Scriptable Object (This SO only needs NextHouses to be Filled)")]
    public HouseUpgradeInfo defaultPlacableHouse;

    // A list of all houses that were placed on this BuildingSlot
    [HideInInspector]
    public List<HouseUpgradeInfo> placedHouses;

    // A reference to the particle system used to show which BuildingSlot is focused
    public GameObject focusedParticleSystem;

    // A reference to the current house GameObject on this slot
    private GameObject spawnedHouse;

    public void Start() {
        placedHouses.Add(defaultPlacableHouse);
    }

    /// <summary>
    /// Function that checks if the player has enough resources to build
    /// </summary>
    /// <param name="woodCost"> The wood cost required </param>
    /// <param name="stoneCost"> The stone cost required </param>
    /// <param name="metalCost">The metal cost required </param>
    /// <returns> If the function was able to spend the resources </returns>
    public bool TrySpendingResources (int woodCost, int stoneCost, int metalCost) {
        ref ResourceStatistics resourceStats = ref PlayerResources.instance.resourceStats; // Reference to the memory of player's resource statistics
        if (woodCost <= resourceStats.woodResource.Amount && stoneCost <= resourceStats.stoneResource.Amount && metalCost <= resourceStats.metalResource.Amount) {
            resourceStats.SubtractFromAllResources(woodCost, stoneCost, metalCost); // Spending resources
            return true;
        }
        
        return false;
    }

    /// <summary>
    /// Checks if there is a next building to spawn and spawns the building
    /// </summary>
    /// <param name="houseToPlace"></param>
    public void SpawnNextBuilding (HouseUpgradeInfo houseToPlace) {
        if (placedHouses[placedHouses.Count-1].nextHouses.Count <= 0) 
        {
            // No next building
            Debug.Log("Maxed out the upgrades");
            return;
        }

        SpawnBuilding(houseToPlace);
    }

    /// <summary>
    /// Checks if there is a building to downgrade to
    /// </summary>
    /// <returns> If it is possible to downgrade </returns>
    public bool CanDowngradeBuilding() {
        //Checks the last two items of the placedHouses List to check if there are any houses available in the history
        if (placedHouses[placedHouses.Count -1] != defaultPlacableHouse && placedHouses[placedHouses.Count -2] != defaultPlacableHouse) {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Prepares BuildingSlot to spawn previous building
    /// </summary>
    public void SpawnPreviousBuilding() {
        HouseUpgradeInfo houseToPlace = placedHouses[placedHouses.Count -2];
        placedHouses.RemoveRange(placedHouses.Count-2, 2);
        SpawnBuilding(houseToPlace);
    }

    /// <summary>
    /// Spawns specified building
    /// </summary>
    /// <param name="houseToPlace"> House Information SO to spawn</param>
    private void SpawnBuilding(HouseUpgradeInfo houseToPlace) {
        if (spawnedHouse != null) { 
            Destroy(spawnedHouse);
        }

        spawnedHouse = Instantiate(houseToPlace.housePrefab);

        spawnedHouse.transform.parent = gameObject.transform;
        spawnedHouse.transform.localPosition = Vector3.zero;

        if (placedHouses[placedHouses.Count-1].nextHouses.Count > 0) {
            placedHouses.Add(houseToPlace);
        }
    }

    /// <summary>
    /// Checks if building exists to be destroyed
    /// </summary>
    /// <returns> If can destroy building</returns>
    public bool CanDestroyBuilding() {
        if (placedHouses.Count > 1) {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Clearing the slot from any bindings and returns them the BuildingSlot to default
    /// </summary>
    public void ReturnBuildingSlotToDefault () {
        Destroy(spawnedHouse);
        HouseUpgradeInfo emptyHouseInfo = placedHouses[0];
        placedHouses.Clear();
        placedHouses.Add(emptyHouseInfo);
    }
}
