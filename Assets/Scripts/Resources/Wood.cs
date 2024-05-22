using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wood : Resource
{

    protected override void OverrideAmountSet() {
        base.OverrideAmountSet();

        SetTMPText(CanvasManager.instance.currentWoodAmountText, Amount.ToString());
    }
}
