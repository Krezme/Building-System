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

    public ResourceStatistics resourceStats;

    void Start () {
        resourceStats.SetDefaultResourceAmount();
    }

    public void AddWoodResourceButton() {
        resourceStats.woodResource.AddResourceButtonClick();
    }

    public void AddStoneResourceButton() {
        resourceStats.stoneResource.AddResourceButtonClick();
    }

    public void AddMetalResourceButton() {
        resourceStats.metalResource.AddResourceButtonClick();
    }
}
