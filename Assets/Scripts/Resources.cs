using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Resources : MonoBehaviour //! Can divide this into inherited classes
{
    #region Singleton
    public static Resources instance;

    void Awake () {
        if (instance != null) {
            Debug.LogError("There is more than one Resources class");
            Destroy(this.gameObject);
        }
        else {
            instance = this;
        }
    }
    #endregion

    public int startingWood;
    public int startingStone;
    public int startingMetal;

    private int wood;
    private int stone;
    private int metal;

    public int Wood {
        get { return wood; }
        private set { 
            wood = value;
            SetTMPText(CanvasManager.instance.currentWoodAmountText, wood.ToString());
        }
    }

    public int Stone {
        get { return stone; }
        private set { 
            stone = value;
            SetTMPText(CanvasManager.instance.currentStoneAmountText, stone.ToString());
        }
    }

    public int Metal {
        get { return metal; }
        private set { 
            metal = value;
            SetTMPText(CanvasManager.instance.currentMetalAmountText, metal.ToString());
        }
    }

    void Start () {
        AddWood(startingWood);
        AddStone(startingStone);
        AddMetal(startingMetal);
    }

    private void SetTMPText(TMP_Text textOnScreen, string text) {
        textOnScreen.text = text;
    }

    public void AddWood (int amount) {
        Wood += amount;
    }

    public void SubtractWood(int amount) {
        if (amount <= Wood) {
            Wood -= amount;
        }
    }

    public void AddStone (int amount) {
        Stone += amount;
    }

    public void SubtractStone(int amount) {
        if (amount <= Stone) {
            Stone -= amount;
        }
    }

    public void AddMetal (int amount) {
        Metal += amount;
    }

    public void SubtractMetal(int amount) {
        if (amount <= Metal) {
            Metal -= amount;
        }
    }
}
