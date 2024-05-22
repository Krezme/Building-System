using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
