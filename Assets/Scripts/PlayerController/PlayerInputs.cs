using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{   
    #region Singleton
    public static PlayerInputs instance;

    void Awake() {
        if (instance != null) {
            Destroy(this);
        }
        else {
            instance = this;
        }
    }
    #endregion

    public Vector2 onMove;

    public Vector2 onLook;

    public bool onFire0;

    public bool onFire1;

    public bool onSprint;

    public void OnMove(InputValue value) {
        MoveInput(value.Get<Vector2>());
    }

    public void OnLook(InputValue value)
    {
        LookInput(value.Get<Vector2>());
    }

    public void OnFire0(InputValue value) {
        Fire0Input(value.isPressed);
    }

    public void OnFire1(InputValue value) {
        Fire1Input(value.isPressed);
    }

    public void OnSprint(InputValue value) {
        SprintInput(value.isPressed);
    }

    public void MoveInput(Vector2 newMoveDirection)
    {
        onMove = newMoveDirection;
    } 

    public void LookInput(Vector2 newLookDirection)
    {
        onLook = newLookDirection;
    }

    public void Fire0Input(bool isPressed) {
        onFire0 = isPressed;
    }

    public void Fire1Input(bool isPressed) {
        onFire1 = isPressed;
    }

    public void SprintInput(bool isPressed) {
        onSprint = isPressed;
    }
} 
