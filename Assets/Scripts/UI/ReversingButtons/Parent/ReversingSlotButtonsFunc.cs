using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ReversingSlotButtonsFunc : MonoBehaviour
{
    [Tooltip("Reversing Slot Button")]
    public Button button;

    /// <summary>
    /// Abstract function to check if according button is pressable 
    /// </summary>
    /// <returns> If the button can be pressed </returns>
    public abstract bool IsButtonAvailable();

    /// <summary>
    /// Functionality for the Reverse BuildingSlot Button
    /// </summary>
    public virtual void ReverseBuildingSlot() {
        FocusSlotFunc.ResetFocus();
    }
}
