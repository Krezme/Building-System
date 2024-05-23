using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildRequestUI : MonoBehaviour
{
    [Tooltip("The building name text of the element")]
    public TMP_Text nameText;

    [Tooltip("The Resources text components responsible to show resource requirements to build")]
    public ResourcesTMP_TextComponents resourcesCostAmountTexts;

    [Tooltip("Button to upgrade building")]
    public Button button;

    // HouseUpgradeInfoToShow reference to get values for the potential house upgrade
    private HouseUpgradeInfo houseUpgradeInfoToShow;

    // BuildingSlot Upgrade function to activate
    private BuildingSlot buildingSlotToActivate;
    
    /// <summary>
    /// Function to record the variables for this BuildRequestUI element
    /// <param name="houseToShow"> HouseUpgradeInfo values to show </param>
    /// <param name="buildingSlot"> BuildingSlot to upgrade </param>
    public void SetVariables (HouseUpgradeInfo houseToShow, BuildingSlot buildingSlot) {
        houseUpgradeInfoToShow = houseToShow;
        buildingSlotToActivate = buildingSlot;
        BuildingRequest();
    }

    /// <summary>
    /// Function to set all of the text fields to the correct amounts
    /// </summary>
    private void BuildingRequest() {
        nameText.text = houseUpgradeInfoToShow.buildingName;
        resourcesCostAmountTexts.woodText.text = houseUpgradeInfoToShow.woodRequired.ToString();
        resourcesCostAmountTexts.stoneText.text = houseUpgradeInfoToShow.stoneRequired.ToString();
        resourcesCostAmountTexts.metalText.text = houseUpgradeInfoToShow.metalRequired.ToString();
        button.onClick.AddListener(() => TryBuilding());
    }

    /// <summary>
    /// Function that attempts to build upgrade
    /// </summary>
    public void TryBuilding() {
        if (buildingSlotToActivate.TrySpendingResources(houseUpgradeInfoToShow.woodRequired, houseUpgradeInfoToShow.stoneRequired, houseUpgradeInfoToShow.metalRequired)) {
            buildingSlotToActivate.SpawnNextBuilding(houseUpgradeInfoToShow);
            button.onClick.RemoveAllListeners();
            FocusSlotFunc.ResetFocus();
        }
    }
}
