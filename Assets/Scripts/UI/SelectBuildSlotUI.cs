using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectBuildSlotUI : MonoBehaviour
{
    [Tooltip("Text component to display name of building slot")]
    public TMP_Text textComponent;

    [Tooltip("Building Slot to focus")]
    public BuildingSlot buildingSlot;

    /// <summary>
    /// Call Focus Function on button press
    /// </summary>
    public void SelectBuildSlotButton() {
        FocusSlotFunc.TryToFocusBuildingSlot(buildingSlot, true);
    }
}
