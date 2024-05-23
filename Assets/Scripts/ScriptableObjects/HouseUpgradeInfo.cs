using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newHouseUpgradeInfo", menuName = "ScriptableObjects/HouseUpgradeInfo")]
public class HouseUpgradeInfo : ScriptableObject
{
    [Tooltip("Building Name to display")]
    public string buildingName;

    [Tooltip("House prefab to spawn")]
    public GameObject housePrefab;

    [Tooltip("Resource required to build building")]
    public int woodRequired, stoneRequired, metalRequired;

    [Tooltip("List for Next upgradable buildings")]
    public List<HouseUpgradeInfo> nextHouses;
}
