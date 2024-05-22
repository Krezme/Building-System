using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyButtonFunc : ReversingSlotButtonsFunc
{
    public override bool IsButtonAvailable() {
        return FocusSlotFunc.focusedBuildingSlot.CanDestroyBuilding();
    }

    public override void ReverseBuildingSlot()
    {
        if (FocusSlotFunc.focusedBuildingSlot != null) {
            FocusSlotFunc.focusedBuildingSlot.ReturnBuildingSlotToDefault();
        }
        base.ReverseBuildingSlot();
    }
}
