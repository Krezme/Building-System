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
    [Header("Player Movement Statistics")]
    public float sensitivity;
    public float normalSpeed;
    public float sprintSpeed;

    [Header("Raycast Info")]
    public LayerMask layerMask;

    void Update()
    {
        PlayerMovement ();

        OnClick();
        PlayerInputs.instance.onFire0 = false;
        //PlayerInputs.instance.onFire1 = false;
    }

    void OnClick () {
        if (!PlayerInputs.instance.onFire0 || EventSystem.current.IsPointerOverGameObject()) {
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

    

    public void PlayerMovement () {
        if(PlayerInputs.instance.onFire1) //if we are holding right click
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Movement();
            Rotation();
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void Movement()
    {
        Vector3 movementInput = new Vector3(PlayerInputs.instance.onMove.x, 0f, PlayerInputs.instance.onMove.y);
        float currentSpeed = PlayerInputs.instance.onSprint ? sprintSpeed : normalSpeed;
        transform.Translate(movementInput * currentSpeed * Time.deltaTime);
    }

    public void Rotation()
    {
        Vector3 mouseInput = new Vector3(-PlayerInputs.instance.onLook.y, PlayerInputs.instance.onLook.x, 0);
        transform.Rotate(mouseInput * sensitivity * Time.deltaTime);
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0);
    }
}
