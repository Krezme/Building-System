using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingRequestPanelUI : MonoBehaviour
{
    public RectTransform mask;
    public GameObject buildingRequestUIPrefab;
    public Animator animator;
    
    private bool hasFocusedBuildingSlot;

    public bool HasFocusedBuildingSlot {
        get { return hasFocusedBuildingSlot; }
        set {
            hasFocusedBuildingSlot = value;
            if (!hasFocusedBuildingSlot) {
                CanvasManager.instance.ClearBuildRequestUIsList();
            } 
            ToggleAnimation(hasFocusedBuildingSlot);
            CheckDestroyButtonAvailability();
        }
    }

    public GameObject InstantiateBuildRequestUI() {
        GameObject newBuildRequestUI = Instantiate(buildingRequestUIPrefab, mask.transform);
        CanvasManager.instance.buildRequestUIs.Add(newBuildRequestUI.GetComponent<BuildRequestUI>());
        return newBuildRequestUI;
    }

    public void CheckDestroyButtonAvailability() {
        if (HasFocusedBuildingSlot) {
            Debug.Log("ASDASDASD");
            CanvasManager.instance.destroyButtonFunc.button.interactable = PlayerController.instance.focusedBuildingSlot.CanDestroyBuilding();
        }
    }

    private void ToggleAnimation (bool state) {
        animator.SetBool("Show", state);
    }
}
