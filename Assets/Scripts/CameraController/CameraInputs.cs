using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraInputs : MonoBehaviour
{   
    #region Sigleton
    public static CameraInputs instance;

    void Awake() {
        if (instance != null) {
            Destroy(this);
        }
        else {
            instance = this;
        }
    }
    #endregion

    public bool onFire;

    public void OnFire(InputValue value) {
        FireInput(value.isPressed);
    }

    public void FireInput(bool isPressed) {
        onFire = isPressed;
    }

    /* public bool isCursorLocked;
    public Vector2 move;
    public Vector2 look;
    
    public void OnMove(InputValue value)
    {
        MoveInput(value.Get<Vector2>());
    }

    public void OnLook(InputValue value)
    {
        if (!isCursorLocked){
            LookInput(value.Get<Vector2>());
        }
    }

    public void MoveInput(Vector2 newMoveDirection)
    {
        move = newMoveDirection;
    } 

    public void LookInput(Vector2 newLookDirection)
    {
        look = newLookDirection;
    }*/
} 
