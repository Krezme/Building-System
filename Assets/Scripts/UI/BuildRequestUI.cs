using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildRequestUI : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text woodCostAmountText;
    public TMP_Text stoneCostAmountText;
    public TMP_Text metalCostAmountText;
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
        woodCostAmountText.text = houseUpgradeInfoToShow.woodRequired.ToString();
        stoneCostAmountText.text = houseUpgradeInfoToShow.stoneRequired.ToString();
        metalCostAmountText.text = houseUpgradeInfoToShow.metalRequired.ToString();
        button.onClick.AddListener(() => TryBuilding());
    }

    public void TryBuilding() {
        if (buildingSlotToActivate.TrySpendingResources(houseUpgradeInfoToShow.woodRequired, houseUpgradeInfoToShow.stoneRequired, houseUpgradeInfoToShow.metalRequired)) {
            buildingSlotToActivate.SpawnNextBuilding(houseUpgradeInfoToShow);
            button.onClick.RemoveAllListeners();
            PlayerController.instance.ResetFocus();
        }
    }
}
