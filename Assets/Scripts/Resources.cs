using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
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

    public Wood woodResource;
    public Stone stoneResource;
    public Metal metalResource;

    void Start () {
        woodResource.AddResource(woodResource.startAmount);
        stoneResource.AddResource(stoneResource.startAmount);
        metalResource.AddResource(metalResource.startAmount);
    }

    public void AddWoodResourceButton() {
        woodResource.AddResourceButtonClick();
    }

    public void AddStoneResourceButton() {
        stoneResource.AddResourceButtonClick();
    }

    public void AddMetalResourceButton() {
        metalResource.AddResourceButtonClick();
    }
}
