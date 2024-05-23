using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public abstract class Resource
{
    [Tooltip("The amount of resource to start with")]
    public int startAmount;

    [Tooltip("The amount of resource to add with the Add Resource Button")]
    public int amountToAddPerButtonClick;

    //current resource amount
    private int amount;

    public int Amount {
        get { return amount; }
        set { 
            amount = value;
            AmountSetOverride();
        }
    }
    
    /// <summary>
    /// Abstract function to be able to run functionality when the resource amount is set
    /// </summary>
    protected abstract void AmountSetOverride ();

    /// <summary>
    /// Function to add to the resource amount
    /// </summary>
    /// <param name="amountToAdd"> Amount to add </param>
    public void AddResource(int amountToAdd) {
        
        Amount += amountToAdd;
    }

    /// <summary>
    /// Function that can be referenced so the Add resource button can add the correct amount
    /// </summary>
    public void AddResourceButtonClick() {
        AddResource(amountToAddPerButtonClick);
    }

    /// <summary>
    /// Function that can Subtract from the resource amount
    /// </summary>
    /// <param name="amountToSubtract"> Amount to Subtract</param>
    public void SubtractResource(int amountToSubtract) {
        if (amountToSubtract <= Amount) {
            Amount -= amountToSubtract;
        }
    }

    /// <summary>
    /// Function that sets the relevant text on screen for the current resource
    /// </summary>
    /// <param name="textOnScreen"> Text to change</param>
    /// <param name="text"> Text to change to</param>
    protected void SetTMPText(TMP_Text textOnScreen, string text) {
        textOnScreen.text = text;
    }
}
