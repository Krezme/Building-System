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

    void Update()
    {
        OnClick();
        PlayerInputs.instance.onFire = false;
    }

    void OnClick () {
        if (!PlayerInputs.instance.onFire || EventSystem.current.IsPointerOverGameObject()) {
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10000f, layerMask)) {
            FocusSlotFunc.TryToFocusBuildingSlot(hit.collider.gameObject.GetComponent<BuildingSlot>(), true);
        }
        else {
            if (FocusSlotFunc.focusedBuildingSlot != null) {
                FocusSlotFunc.ResetFocus();
            }
        }
    }
}
