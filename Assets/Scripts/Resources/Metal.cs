using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Metal : Resource
{

    protected override void AmountSetOverride() {
        SetTMPText(CanvasManager.instance.currentResourcesAmountTexts.metalText, Amount.ToString());
    }
}
