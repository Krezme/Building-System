using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DowngradeButtonFunc : ReversingSlotButtonsFunc
{
    public override bool IsButtonAvailable() {
        return PlayerController.instance.focusedBuildingSlot.CanDowngradeBuilding();
    }
    public override void ReverseBuildingSlot()
    {
        PlayerController.instance.focusedBuildingSlot.SpawnPreviousBuilding();
        base.ReverseBuildingSlot();
    }
}
