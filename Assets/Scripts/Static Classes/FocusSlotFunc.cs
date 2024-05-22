using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FocusSlotFunc
{
    private static bool hasFocusedBuildingSlot;

    public delegate void OnHasFocusedBuildingSlot();
    public static OnHasFocusedBuildingSlot onHasFocusedBuildingSlot;

    public static bool HasFocusedBuildingSlot {
        get { return hasFocusedBuildingSlot; }
        set {
            hasFocusedBuildingSlot = value;
            onHasFocusedBuildingSlot();
        }
    }

    public static BuildingSlot focusedBuildingSlot;

    public static void ResetFocus() {
        SetFocusedBuildingSlot(focusedBuildingSlot, false);
    }

    public static bool TryToFocusBuildingSlot(BuildingSlot buildingSlotToFocus, bool focusState) {
        if (focusedBuildingSlot != buildingSlotToFocus) {
            if (focusedBuildingSlot != null) {
                ResetFocus();
            }

            SetFocusedBuildingSlot(buildingSlotToFocus, true);
            return true;
        }

        return false;
    }

    private static void SetFocusedBuildingSlot (BuildingSlot buildingSlotToFocus, bool focusState) {
        if (focusState) {
            focusedBuildingSlot = buildingSlotToFocus;
        }
        else {
            HasFocusedBuildingSlot = false;
            focusedBuildingSlot = null;
        }
        SetBuildingSlotFocus(focusedBuildingSlot, focusState);
    }

    public static void SetBuildingSlotFocus(BuildingSlot newFocusedBuildingSlot, bool state) {
        HasFocusedBuildingSlot = state;
        if (HasFocusedBuildingSlot) {
            for (int i = 0; i < newFocusedBuildingSlot.placableHouses[newFocusedBuildingSlot.placableHouses.Count -1].nextHouses.Count; i++) {
                CanvasManager.instance.buildingRequestScrollGridPanel.InstantiateBuildRequestUI();
                CanvasManager.instance.buildRequestUIs[i].SetVariables(newFocusedBuildingSlot.placableHouses[newFocusedBuildingSlot.placableHouses.Count -1].nextHouses[i], newFocusedBuildingSlot);
            }
        }
    }
}
