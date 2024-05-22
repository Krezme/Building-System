using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildRequestUI : MonoBehaviour
{
    public Animator animator;

    public TMP_Text nameText;
    public TMP_Text woodCostAmountText;
    public TMP_Text stoneCostAmountText;
    public TMP_Text metalCostAmountText;
    public Button button;

    private bool focusedBuildingSlot;

    public bool FocusedBuildingSlot {
        get { return focusedBuildingSlot; }
        set {
            focusedBuildingSlot = value;
            ToggleAnimation(focusedBuildingSlot); 
        }
    }

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
        if (buildingSlotToActivate.TrySpendResources(houseUpgradeInfoToShow.woodRequired, houseUpgradeInfoToShow.stoneRequired, houseUpgradeInfoToShow.metalRequired)) {
            PlayerController.instance.ResetFocus();
            buildingSlotToActivate.SpawnNextHouse(houseUpgradeInfoToShow);
            button.onClick.RemoveAllListeners();
        }
    }

    private void ToggleAnimation (bool state) {
        animator.SetBool("Show", state);
    }
}
