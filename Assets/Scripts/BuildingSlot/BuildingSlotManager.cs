using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSlotManager : MonoBehaviour
{
    // Array of all buildingSlots that are children to this GameObject
    [HideInInspector]
    public BuildingSlot[] buildingSlots;

    /// <summary>
    /// Gets all BuildingSlots from the children
    /// </summary>
    void Awake() {
        buildingSlots = GetComponentsInChildren<BuildingSlot>();
    }

    /// <summary>
    /// Initiates the instantiation for each BuildingSlot
    /// </summary>
    void Start() {
        SetupBuildingSlotsPanel();
    }

    /// <summary>
    /// Calls the Instantiation for the UI Buttons that focus BuildingSlots
    /// </summary>
    private void SetupBuildingSlotsPanel() {
        if (buildingSlots.Length > 0) {
            foreach (BuildingSlot slot in buildingSlots) {
                CanvasManager.instance.buildingSlotsPanelUI.InstantiateSelectSlotButtonPrefab(slot);
            }
        }
    }
}
