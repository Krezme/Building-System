using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    #region Singleton
    public static PlayerResources instance;

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

    [Tooltip("Resource statistics and the currently available resources to the player")]
    public ResourceStatistics resourceStats;

    void Start () {
        resourceStats.SetDefaultResourceAmount();
    }

    /// <summary>
    /// Function that the Button to Add Wood can call to add the wood
    /// </summary>
    public void AddWoodResourceButton() {
        resourceStats.woodResource.AddResourceButtonClick();
    }

    /// <summary>
    /// Function that the Button to Add Stone can call to add the wood
    /// </summary>
    public void AddStoneResourceButton() {
        resourceStats.stoneResource.AddResourceButtonClick();
    }

    /// <summary>
    /// Function that the Button to Add Metal can call to add the wood
    /// </summary>
    public void AddMetalResourceButton() {
        resourceStats.metalResource.AddResourceButtonClick();
    }
}
