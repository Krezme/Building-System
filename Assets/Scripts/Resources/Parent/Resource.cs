using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Resource
{
    public int startAmount;
    public int amountToAddPerButtonClick;
    private int amount;

    public int Amount {
        get { return amount; }
        set { 
            amount = value;
            OverrideAmountSet();
        }
    }
    
    protected virtual void OverrideAmountSet () {}

    public void AddResource(int amountToAdd) {
        
        Amount += amountToAdd;
    }

    public void AddResourceButtonClick() {
        AddResource(amountToAddPerButtonClick);
    }

    public void SubtractResource(int amountToSubtract) {
        if (amountToSubtract <= Amount) {
            Amount -= amountToSubtract;
        }
    }

    protected void SetTMPText(TMP_Text textOnScreen, string text) {
        textOnScreen.text = text;
    }
}
