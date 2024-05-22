using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    #region Singleton
    public static CanvasManager instance;

    void Awake () {
        if (instance != null) {
            Debug.LogError("There are two Canvas Managers in the project");
            Destroy(this.gameObject);
        }   
        else {
            instance = this;
        }
    }
    #endregion

    [Header("BuildingSlot References")]
    public BuildingSlotsPanelUI buildingSlotsPanelUI;

    [Header("BuildingRequest References")]
    public BuildingRequestPanelUI buildingRequestScrollGridPanel;
    public List<BuildRequestUI> buildRequestUIs;

    [Header("Resources References")]
    public ResourcesTMP_TextComponents currentResourcesAmountTexts;

    public void ClearBuildRequestUIsList() {
        for (int i = 0; i < buildRequestUIs.Count; i++) {
            Destroy(buildRequestUIs[i].gameObject);
        }
        buildRequestUIs.Clear();
    }

    public void ToggleButtonInteractivity(Button button, bool state) {
        button.interactable = state;
    }
}
