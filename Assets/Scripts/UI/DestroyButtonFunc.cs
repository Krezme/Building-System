using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyButtonFunc : MonoBehaviour
{
    public Button button;
    public void DestroyHouse() {
        PlayerController.instance.focusedBuildingSlot.ReturnBuildingSlotToDefault();
        PlayerController.instance.ResetFocus();
    }
}
