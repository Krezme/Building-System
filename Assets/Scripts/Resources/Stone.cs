using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stone : Resource
{
    protected override void AmountSetOverride() {
        SetTMPText(CanvasManager.instance.currentResourcesAmountTexts.stoneText, Amount.ToString());
    }
}
