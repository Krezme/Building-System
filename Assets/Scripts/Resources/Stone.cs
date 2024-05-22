using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stone : Resource
{
    protected override void OverrideAmountSet() {
        base.OverrideAmountSet();

        SetTMPText(CanvasManager.instance.currentStoneAmountText, Amount.ToString());
    }
}
