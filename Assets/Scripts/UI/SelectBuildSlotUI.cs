using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectBuildSlotUI : MonoBehaviour
{
    public TMP_Text textComponent;
    public BuildingSlot buildingSlot;

    public void SelectBuildSlotButton() {
        FocusSlotFunc.TryToFocusBuildingSlot(buildingSlot, true);
    }
}
