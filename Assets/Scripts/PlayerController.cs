using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    
    void Awake() {
        if (instance != null) {
            Debug.LogError("There is more than one Player Controller!");
            Destroy(this.gameObject);
        }
        else {
            instance = this;
        }
    }

    public LayerMask layerMask;

    public BuildingSlot focusedBuildingSlot {get; private set;} 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnClick();
        CameraInputs.instance.onFire = false;
    }

    void OnClick () {
        if (!CameraInputs.instance.onFire || EventSystem.current.IsPointerOverGameObject()) {
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10000f, layerMask)) {
            TryToFocusBuildingSlot(hit.collider.gameObject.GetComponent<BuildingSlot>(), true);
        }
        else {
            if (focusedBuildingSlot != null) {
                ResetFocus();
            }
        }
    }

    public void ResetFocus() {
        SetFocusedBuildingSlot(focusedBuildingSlot, false);
    }

    public bool TryToFocusBuildingSlot(BuildingSlot buildingSlotToFocus, bool focusState) {
        if (focusedBuildingSlot != buildingSlotToFocus) {
            if (focusedBuildingSlot != null) {
                ResetFocus();
            }

            SetFocusedBuildingSlot(buildingSlotToFocus, true);
            return true;
        }

        return false;
    }

    private void SetFocusedBuildingSlot (BuildingSlot buildingSlotToFocus, bool focusState) {
        if (focusState) {
            focusedBuildingSlot = buildingSlotToFocus;
        }
        else {
            CanvasManager.instance.buildingRequestScrollGridPanel.HasFocusedBuildingSlot = false;
            focusedBuildingSlot = null;
        }
        buildingSlotToFocus.FocusThis(focusState);
    }
}
