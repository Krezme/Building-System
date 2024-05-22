using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DowngradeButtonFunc : ReversingSlotButtonsFunc
{
    public override bool IsButtonAvailable() {
        return FocusSlotFunc.focusedBuildingSlot.CanDowngradeBuilding();
    }
    public override void ReverseBuildingSlot()
    {
        FocusSlotFunc.focusedBuildingSlot.SpawnPreviousBuilding();
        base.ReverseBuildingSlot();
    }
}
