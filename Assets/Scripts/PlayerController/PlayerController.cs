using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerController : MonoBehaviour
{
    #region Singleton
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
    #endregion

    [Header("Player Movement Statistics")]
    [Tooltip("Mouse sensitivity for looking around")]
    public float mouseSensitivity;
    [Tooltip("Movement speed for when the player is not sprinting")]
    public float normalSpeed;
    [Tooltip("Movement speed for when the player is sprinting")]
    public float sprintSpeed;

    [Header("Raycast Info")]
    [Tooltip("Layer Mask that the Building Slots are assigned with")]
    public LayerMask buildingSlotLayerMask;

    void Update()
    {
        PlayerMovement ();

        OnClick();
        PlayerInputs.instance.onFire0 = false;
    }

    /// <summary>
    /// Checks if player has pressed on a building slot in the world
    /// </summary>
    void OnClick () {
        // Check if the left mouse button is pressed or if the mouse is over UI element
        if (!PlayerInputs.instance.onFire0 || EventSystem.current.IsPointerOverGameObject()) {
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10000f, buildingSlotLayerMask)) {
            FocusSlotFunc.TryToFocusBuildingSlot(hit.collider.gameObject.GetComponent<BuildingSlot>(), true); // Attempting to Focus a detected BuildingSlot
        }
        else {
            if (FocusSlotFunc.focusedBuildingSlot != null) {
                FocusSlotFunc.ResetFocus(); // Unfocus the focused BuildingSlot
            }
        }
    }

    /// <summary>
    /// Function that assembles all aspects of player movement
    /// </summary>
    public void PlayerMovement () {
        if(PlayerInputs.instance.onFire1) //if we are holding right click
        {
            if (FocusSlotFunc.focusedBuildingSlot != null) {
                FocusSlotFunc.ResetFocus(); // Unfocus the focused BuildingSlot
            }
            // Making Cursor invisible
            Cursor.visible = false;
            // Locking cursor
            Cursor.lockState = CursorLockMode.Locked;
            Movement();
            Rotation();
        }
        else
        {
            // Returning Cursor to default
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    /// <summary>
    /// Movement calculation
    /// </summary>
    public void Movement()
    {
        Vector3 movementInput = new Vector3(PlayerInputs.instance.onMove.x, 0f, PlayerInputs.instance.onMove.y);
        // if player is sprinting set speed accordingly
        float currentSpeed = PlayerInputs.instance.onSprint ? sprintSpeed : normalSpeed;
        transform.Translate(movementInput * currentSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Rotation calculation
    /// </summary>
    public void Rotation()
    {
        Vector3 mouseInput = new Vector3(-PlayerInputs.instance.onLook.y, PlayerInputs.instance.onLook.x, 0);
        transform.Rotate(mouseInput * mouseSensitivity * Time.deltaTime);
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 0);
    }
}
