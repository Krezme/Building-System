using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ReversingSlotButtonsFunc : MonoBehaviour
{
    public Button button;

    public abstract bool IsButtonAvailable();

    public virtual void ReverseBuildingSlot() {
        FocusSlotFunc.ResetFocus();
    }
}
