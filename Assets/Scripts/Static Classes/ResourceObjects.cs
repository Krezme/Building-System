using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class ResourceStatistics {
    [Tooltip("Wood Resource Statistics")]
    public Wood woodResource;

    [Tooltip("Stone Resource Statistics")]
    public Stone stoneResource;

    [Tooltip("Metal Resource Statistics")]
    public Metal metalResource;

    /// <summary>
    /// Function to set all of the Resources to the default values
    /// </summary>
    public void SetDefaultResourceAmount() {
        AddToAllResources(woodResource.startAmount, stoneResource.startAmount, woodResource.startAmount);
    }

    /// <summary>
    /// Function to Add to all resources at once
    /// </summary>
    /// <param name="woodAmount"> Wood amount to add </param>
    /// <param name="stoneAmount"> Stone amount to add </param>
    /// <param name="metalAmount"> Metal amount to add </param>
    public void AddToAllResources(int woodAmount, int stoneAmount, int metalAmount) {
        woodResource.AddResource(woodAmount);
        stoneResource.AddResource(stoneAmount);
        metalResource.AddResource(metalAmount);
    }

    /// <summary>
    /// Function to Subtract from all resources at once
    /// </summary>
    /// <param name="woodAmount"> Wood amount to subtract </param>
    /// <param name="stoneAmount"> Stone amount to subtract </param>
    /// <param name="metalAmount"> Metal amount to subtract </param>
    public void SubtractFromAllResources(int woodAmount, int stoneAmount, int metalAmount) {
        woodResource.SubtractResource(woodAmount);
        stoneResource.SubtractResource(stoneAmount);
        metalResource.SubtractResource(metalAmount);
    }
}

[System.Serializable]
public class ResourcesTMP_TextComponents
{
    [Tooltip("TMP Text UI Component to related to Wood amount")]
    public TMP_Text woodText;

    [Tooltip("TMP Text UI Component to related to Stone amount")]
    public TMP_Text stoneText;

    [Tooltip("TMP Text UI Component to related to Metal amount")]
    public TMP_Text metalText;
}
