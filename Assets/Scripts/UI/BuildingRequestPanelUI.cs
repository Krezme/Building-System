using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildingRequestPanelUI : MonoBehaviour
{
    [Tooltip(" Layout Panel inside this game object")]
    public RectTransform layoutPanel;

    [Tooltip("Game object to Instantiate")]
    public GameObject buildingRequestUIPrefab;

    [Tooltip("The animator responsible for this game object")]
    public Animator animator;

    [Tooltip("Button used for downgrading the building on focused BuildingSlot")]
    public DowngradeButtonFunc downgradeButtonFunc;
    [Tooltip("Button used for Destroying the building on focused BuildingSlot")]
    public DestroyButtonFunc destroyButtonFunc;

    void Start () {
        FocusSlotFunc.onHasFocusedBuildingSlot += ActivateOnHasFocusedBuildingSlot;
    }

    /// <summary>
    /// Function to instantiate the UI elements for the building slot upgrades
    /// </summary>
    /// <returns> The instantiated game object </returns>
    public GameObject InstantiateBuildRequestUI() {
        GameObject newBuildRequestUI = Instantiate(buildingRequestUIPrefab, layoutPanel.transform);
        CanvasManager.instance.buildRequestUIs.Add(newBuildRequestUI.GetComponent<BuildRequestUI>());
        return newBuildRequestUI;
    }

    /// <summary>
    /// Function that assembles methods to call when the HasFocusedBuildingSlot variable is set
    /// </summary>
    private void ActivateOnHasFocusedBuildingSlot() {
        if (!FocusSlotFunc.HasFocusedBuildingSlot) {
            CanvasManager.instance.ClearBuildRequestUIsList();
        }
        ToggleAnimation(FocusSlotFunc.HasFocusedBuildingSlot);
        CheckButtonAvailability(downgradeButtonFunc);
        CheckButtonAvailability(destroyButtonFunc);
    }

    /// <summary>
    /// Function to check if the button can be pressed
    /// </summary>
    /// <param name="reversingSlotButtonsFunc"> Button functionality to check </param>
    private void CheckButtonAvailability(ReversingSlotButtonsFunc reversingSlotButtonsFunc) {
        if (FocusSlotFunc.HasFocusedBuildingSlot) {
            reversingSlotButtonsFunc.button.interactable = reversingSlotButtonsFunc.IsButtonAvailable();
        }
    }

    /// <summary>
    /// Function to Toggle the animation of the UI Element
    /// </summary>
    /// <param name="state"> animation state </param>
    private void ToggleAnimation (bool state) {
        animator.SetBool("Show", state);
    }
}
