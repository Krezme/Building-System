using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingRequestPanelUI : MonoBehaviour
{
    public RectTransform layoutPanel;
    public GameObject buildingRequestUIPrefab;
    public Animator animator;

    public DowngradeButtonFunc downgradeButtonFunc;
    public DestroyButtonFunc destroyButtonFunc;
    
    private bool hasFocusedBuildingSlot;

    public bool HasFocusedBuildingSlot {
        get { return hasFocusedBuildingSlot; }
        set {
            hasFocusedBuildingSlot = value;
            if (!hasFocusedBuildingSlot) {
                CanvasManager.instance.ClearBuildRequestUIsList();
            } 
            ToggleAnimation(hasFocusedBuildingSlot);
            CheckButtonAvailability(downgradeButtonFunc);
            CheckButtonAvailability(destroyButtonFunc);
        }
    }

    public GameObject InstantiateBuildRequestUI() {
        GameObject newBuildRequestUI = Instantiate(buildingRequestUIPrefab, layoutPanel.transform);
        CanvasManager.instance.buildRequestUIs.Add(newBuildRequestUI.GetComponent<BuildRequestUI>());
        return newBuildRequestUI;
    }

    private void CheckButtonAvailability(ReversingSlotButtonsFunc reversingSlotButtonsFunc) {
        if (HasFocusedBuildingSlot) {
            reversingSlotButtonsFunc.button.interactable = reversingSlotButtonsFunc.IsButtonAvailable();
        }
    }

    private void ToggleAnimation (bool state) {
        animator.SetBool("Show", state);
    }
}
