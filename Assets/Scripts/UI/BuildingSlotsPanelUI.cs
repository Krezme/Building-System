using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSlotsPanelUI : MonoBehaviour
{
    public GameObject selectSlotButtonPrefab;

    public GameObject layoutPanel;
    
    public void InstantiateSelectSlotButtonPrefab (BuildingSlot buildingSlot) {
        GameObject newSelectSlotButton = Instantiate(selectSlotButtonPrefab, layoutPanel.transform);
        SelectBuildSlotUI selectBuildSlotUI = newSelectSlotButton.GetComponent<SelectBuildSlotUI>();
        selectBuildSlotUI.buildingSlot = buildingSlot;
        selectBuildSlotUI.textComponent.text = buildingSlot.name;
    }
}
