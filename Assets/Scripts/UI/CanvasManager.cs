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
    [Tooltip("The BuildingSlotsPanelUI script that is responsible for the functionality")]
    public BuildingSlotsPanelUI buildingSlotsPanelUI;

    [Header("BuildingRequest References")]
    [Tooltip("The BuildingRequestPanelUI script that is responsible for the functionality")]
    public BuildingRequestPanelUI buildingRequestScrollGridPanel;

    // List of BuildRequestUI that are instantiated on the BuildingRequestPanelUI
    [HideInInspector]
    public List<BuildRequestUI> buildRequestUIs;

    [Header("Resources References")]
    [Tooltip("The Resource text components responsible to show the the current resource amounts")]
    public ResourcesTMP_TextComponents currentResourcesAmountTexts;

    /// <summary>
    /// Function to clear the BuildRequestUI list and return it to default
    /// </summary>
    public void ClearBuildRequestUIsList() {
        for (int i = 0; i < buildRequestUIs.Count; i++) {
            Destroy(buildRequestUIs[i].gameObject);
        }
        buildRequestUIs.Clear();
    }

    /// <summary>
    /// Function that toggles interactable
    /// </summary>
    /// <param name="button"> Button to toggle </param>
    /// <param name="state"> Interactable state </param>
    public void ToggleButtonInteractivity(Button button, bool state) {
        button.interactable = state;
    }
}
