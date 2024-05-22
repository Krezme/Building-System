using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Metal : Resource
{

    protected override void OverrideAmountSet() {
        base.OverrideAmountSet();

        SetTMPText(CanvasManager.instance.currentMetalAmountText, Amount.ToString());
    }
}
