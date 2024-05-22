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

    public bool onFire;

    public void OnFire(InputValue value) {
        FireInput(value.isPressed);
    }

    public void FireInput(bool isPressed) {
        onFire = isPressed;
    }
} 
