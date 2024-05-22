using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBuildSlotUI : MonoBehaviour
{
    public BuildingSlot buildingSlot;

    public void SelectBuildSlotButton() {
        PlayerController.instance.SetFocusedBuildingSlot(buildingSlot, true);
    }
}
