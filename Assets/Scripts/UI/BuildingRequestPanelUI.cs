using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildingRequestPanelUI : MonoBehaviour
{
    public RectTransform layoutPanel;
    public GameObject buildingRequestUIPrefab;
    public TMP_Text maxedOutUpgradesText;
    public Animator animator;

    public DowngradeButtonFunc downgradeButtonFunc;
    public DestroyButtonFunc destroyButtonFunc;

    void Start () {
        FocusSlotFunc.onHasFocusedBuildingSlot += ActivateOnHasFocusedBuildingSlot;
    }

    public GameObject InstantiateBuildRequestUI() {
        GameObject newBuildRequestUI = Instantiate(buildingRequestUIPrefab, layoutPanel.transform);
        CanvasManager.instance.buildRequestUIs.Add(newBuildRequestUI.GetComponent<BuildRequestUI>());
        return newBuildRequestUI;
    }

    private void ActivateOnHasFocusedBuildingSlot() {
        if (!FocusSlotFunc.HasFocusedBuildingSlot) {
            CanvasManager.instance.ClearBuildRequestUIsList();
        }
        ToggleMaxedOutUpgradesText();
        ToggleAnimation(FocusSlotFunc.HasFocusedBuildingSlot);
        CheckButtonAvailability(downgradeButtonFunc);
        CheckButtonAvailability(destroyButtonFunc);
    }

    private void ToggleMaxedOutUpgradesText() {
        maxedOutUpgradesText.enabled = FocusSlotFunc.HasFocusedBuildingSlot && CanvasManager.instance.buildRequestUIs.Count <= 0;
    }

    private void CheckButtonAvailability(ReversingSlotButtonsFunc reversingSlotButtonsFunc) {
        if (FocusSlotFunc.HasFocusedBuildingSlot) {
            reversingSlotButtonsFunc.button.interactable = reversingSlotButtonsFunc.IsButtonAvailable();
        }
    }

    private void ToggleAnimation (bool state) {
        animator.SetBool("Show", state);
    }
}
