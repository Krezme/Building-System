using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildingSlotManager : MonoBehaviour
{
    public BuildingSlot[] buildingSlots;

    void Awake() {
        buildingSlots = GetComponentsInChildren<BuildingSlot>();
    }

    void Start() {
        SetupBuildingSlotsPanel();
    }

    private void SetupBuildingSlotsPanel() {
        if (buildingSlots.Length > 0) {
            foreach (BuildingSlot slot in buildingSlots) {
                CanvasManager.instance.buildingSlotsPanelUI.InstantiateSelectSlotButtonPrefab(slot);
            }
        }
    }
}
