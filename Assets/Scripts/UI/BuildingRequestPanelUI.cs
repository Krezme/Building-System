using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingRequestPanelUI : MonoBehaviour
{
    public RectTransform mask;
    public GameObject buildingRequestUIPrefab;
    public Animator animator;
    
    private bool focusedBuildingSlot;

    public bool FocusedBuildingSlot {
        get { return focusedBuildingSlot; }
        set {
            focusedBuildingSlot = value;
            if (!focusedBuildingSlot) {
                CanvasManager.instance.ClearBuildRequestUIsList();
            } 
            ToggleAnimation(focusedBuildingSlot);
        }
    }

    public GameObject InstantiateBuildRequestUI() {
        Debug.Log("Hello Instantiating");
        GameObject newBuildRequestUI = Instantiate(buildingRequestUIPrefab, mask.transform);
        CanvasManager.instance.buildRequestUIs.Add(newBuildRequestUI.GetComponent<BuildRequestUI>());
        return newBuildRequestUI;
    }

    private void ToggleAnimation (bool state) {
        animator.SetBool("Show", state);
    }
}
