using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FocusSlotFunc
{
    // if player currently has focused a BuildingSlot
    private static bool hasFocusedBuildingSlot;

    /// <summary>
    /// Run Functionality on Focus
    /// </summary>
    public delegate void OnHasFocusedBuildingSlot();
    public static OnHasFocusedBuildingSlot onHasFocusedBuildingSlot;

    public static bool HasFocusedBuildingSlot {
        get { return hasFocusedBuildingSlot; }
        set {
            hasFocusedBuildingSlot = value;
            onHasFocusedBuildingSlot();
        }
    }

    // Focused BuildingSlot
    public static BuildingSlot focusedBuildingSlot;

    /// <summary>
    /// Setting FOcus to Default
    /// </summary>
    public static void ResetFocus() {
        ToggleBuildingSlotFocus(focusedBuildingSlot, false);
    }

    /// <summary>
    /// Attempting to focus a Building slot
    /// </summary>
    /// <param name="buildingSlotToFocus"> Building Slot to focus </param>
    /// <param name="focusState"> Focus state </param>
    /// <returns> If it can be focused </returns>
    public static bool TryToFocusBuildingSlot(BuildingSlot buildingSlotToFocus, bool focusState) {
        if (focusedBuildingSlot != buildingSlotToFocus) {
            if (focusedBuildingSlot != null) {
                ResetFocus();
            }

            ToggleBuildingSlotFocus(buildingSlotToFocus, true);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Toggling the Building Slot Focus
    /// </summary>
    /// <param name="buildingSlotToFocus"> BuildingSlot to Focus </param>
    /// <param name="focusState"> Focus state </param>
    private static void ToggleBuildingSlotFocus (BuildingSlot buildingSlotToFocus, bool focusState) {
        if (focusState) {
            focusedBuildingSlot = buildingSlotToFocus;
            focusedBuildingSlot.focusedParticleSystem.SetActive(focusState);
        }
        else {
            focusedBuildingSlot.focusedParticleSystem.SetActive(focusState);
            HasFocusedBuildingSlot = false;
            focusedBuildingSlot = null;
        }
        SetBuildingSlotFocus(focusedBuildingSlot, focusState);
    }

    /// <summary>
    /// Setting the BuildingSlot to be Focused
    /// </summary>
    /// <param name="newFocusedBuildingSlot"> BuildingSlot to be focused </param>
    /// <param name="state"> Focus state </param>
    public static void SetBuildingSlotFocus(BuildingSlot newFocusedBuildingSlot, bool state) {
        HasFocusedBuildingSlot = state;
        if (HasFocusedBuildingSlot) {
            for (int i = 0; i < newFocusedBuildingSlot.placedHouses[newFocusedBuildingSlot.placedHouses.Count -1].nextHouses.Count; i++) {
                CanvasManager.instance.buildingRequestScrollGridPanel.InstantiateBuildRequestUI();
                CanvasManager.instance.buildRequestUIs[i].SetVariables(newFocusedBuildingSlot.placedHouses[newFocusedBuildingSlot.placedHouses.Count -1].nextHouses[i], newFocusedBuildingSlot);
            }
        }
    }
}
