using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    #region Singleton
    public static CanvasManager instance;

    void Awake () {
        if (instance != null) {
            Debug.LogError("There are two Canvas Managers in the project");
            Destroy(this.gameObject);
        }   
        else {
            instance = this;
        }
    }
    #endregion
    
    public List<BuildRequestUI> buildRequestUIs;
    public TMP_Text currentWoodAmountText;
    public TMP_Text currentStoneAmountText;
    public TMP_Text currentMetalAmountText;
}
