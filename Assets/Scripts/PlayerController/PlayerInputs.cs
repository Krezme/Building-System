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

    [Tooltip("Current move values")]
    public Vector2 onMove;

    [Tooltip("Current mouse values")]
    public Vector2 onLook;

    [Tooltip("Current state of left mouse button")]
    public bool onFire0;

    [Tooltip("Current state of right mouse button")]
    public bool onFire1;

    [Tooltip("Current state to left shift button")]
    public bool onSprint;

    /// <summary>
    /// Getting movement values from the NewInputSystem
    /// </summary>
    /// <param name="value"> movement values </param>
    public void OnMove(InputValue value) {
        MoveInput(value.Get<Vector2>());
    }

    /// <summary>
    /// Getting mouse values from the NewInputSystem
    /// </summary>
    /// <param name="value"> mouse values </param>
    public void OnLook(InputValue value)
    {
        LookInput(value.Get<Vector2>());
    }

    /// <summary>
    /// Getting left mouse button values from the NewInputSystem
    /// </summary>
    /// <param name="value"> Left mouse values </param>
    public void OnFire0(InputValue value) {
        Fire0Input(value.isPressed);
    }

    /// <summary>
    /// Getting right mouse button values from the NewInputSystem
    /// </summary>
    /// <param name="value"> Right mouse values </param>
    public void OnFire1(InputValue value) {
        Fire1Input(value.isPressed);
    }

    /// <summary>
    /// Getting left shift button values from the NewInputSystem
    /// </summary>
    /// <param name="value"> Left shift values </param>
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
