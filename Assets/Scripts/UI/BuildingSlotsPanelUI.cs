using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSlotsPanelUI : MonoBehaviour
{
    [Tooltip("Prefab to instantiate")]
    public GameObject selectSlotButtonPrefab;

    [Tooltip("The Layout Panel inside to this game object")]
    public GameObject layoutPanel;
    
    /// <summary>
    /// Function to instantiate the button prefab and connect it to a BuildingSlot
    /// </summary>
    /// <param name="buildingSlot"> BuildingSlot to connect to </param>
    public void InstantiateSelectSlotButtonPrefab (BuildingSlot buildingSlot) {
        GameObject newSelectSlotButton = Instantiate(selectSlotButtonPrefab, layoutPanel.transform);
        SelectBuildSlotUI selectBuildSlotUI = newSelectSlotButton.GetComponent<SelectBuildSlotUI>();
        selectBuildSlotUI.buildingSlot = buildingSlot;
        selectBuildSlotUI.textComponent.text = buildingSlot.name;
    }
}
