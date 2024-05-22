using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildRequestUI : MonoBehaviour
{
    public TMP_Text nameText;
    public ResourcesTMP_TextComponents resourcesCostAmountTexts;
    public Button button;

    private HouseUpgradeInfo houseUpgradeInfoToShow;
    private BuildingSlot buildingSlotToActivate;
    

    public void SetVariables (HouseUpgradeInfo houseToShow, BuildingSlot buildingSlot) {
        houseUpgradeInfoToShow = houseToShow;
        buildingSlotToActivate = buildingSlot;
        BuildingRequest();
    }

    private void BuildingRequest() {
        nameText.text = houseUpgradeInfoToShow.buildingName;
        resourcesCostAmountTexts.woodText.text = houseUpgradeInfoToShow.woodRequired.ToString();
        resourcesCostAmountTexts.stoneText.text = houseUpgradeInfoToShow.stoneRequired.ToString();
        resourcesCostAmountTexts.metalText.text = houseUpgradeInfoToShow.metalRequired.ToString();
        button.onClick.AddListener(() => TryBuilding());
    }

    public void TryBuilding() {
        if (buildingSlotToActivate.TrySpendingResources(houseUpgradeInfoToShow.woodRequired, houseUpgradeInfoToShow.stoneRequired, houseUpgradeInfoToShow.metalRequired)) {
            buildingSlotToActivate.SpawnNextBuilding(houseUpgradeInfoToShow);
            button.onClick.RemoveAllListeners();
            FocusSlotFunc.ResetFocus();
        }
    }
}
