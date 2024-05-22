using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newHouseUpgradeInfo", menuName = "ScriptableObjects/HouseUpgradeInfo")]
public class HouseUpgradeInfo : ScriptableObject
{
    public string buildingName;
    public GameObject housePrefab;
    public int woodRequired, stoneRequired, metalRequired;

    public List<HouseUpgradeInfo> nextHouses;
}
