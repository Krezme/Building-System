using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class ResourceStatistics {
    public Wood woodResource;
    public Stone stoneResource;
    public Metal metalResource;

    public void AddToAllResources(int woodAmount, int stoneAmount, int metalAmount) {
        woodResource.AddResource(woodAmount);
        stoneResource.AddResource(stoneAmount);
        metalResource.AddResource(metalAmount);
    }

    public void SubtractFromAllResources(int woodAmount, int stoneAmount, int metalAmount) {
        woodResource.SubtractResource(woodAmount);
        stoneResource.SubtractResource(stoneAmount);
        metalResource.SubtractResource(metalAmount);
    }
}

[System.Serializable]
public class ResourcesTMP_TextComponents
{
    public TMP_Text woodText;
    public TMP_Text stoneText;
    public TMP_Text metalText;
}
