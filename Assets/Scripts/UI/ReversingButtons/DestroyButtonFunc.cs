using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyButtonFunc : ReversingSlotButtonsFunc
{
    public override bool IsButtonAvailable() {
        return PlayerController.instance.focusedBuildingSlot.CanDestroyBuilding();
    }

    public override void ReverseBuildingSlot()
    {
        PlayerController.instance.focusedBuildingSlot.ReturnBuildingSlotToDefault();
        base.ReverseBuildingSlot();
    }
}
