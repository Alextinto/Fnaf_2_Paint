using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [Header("Initial Settings")]
    public string roomID;
    public List<VisualInformation> visuals;
    public List<TranslationInformation> translations;
    public bool canHoldMultipleAnimatronics = false;

    [Header("Runtime")]
    public List<AnimatronicID> actualAnimatronicsInRoom;

    public Room GetNextRoom(AnimatronicID animatronicID)
    {
        if (!canHoldMultipleAnimatronics && actualAnimatronicsInRoom.Count > 0)
            return null;

        foreach (var translation in translations)
        {
            if (translation.animatronicID == animatronicID)
            {
                return translation.targetRoom;
            }
        }
        return null;
    }

    public void EnterThisRoom(AnimatronicID animatronicId)
    {
        foreach (var visual in visuals)
        {
            if (visual.animatronicID == animatronicId)
            {
                visual.visualAnimatronic.SetActive(true);
            }
        }
        actualAnimatronicsInRoom.Add(animatronicId);
    }

    public void ExitThisRoom(AnimatronicID animatronicId)
    {
        foreach (var visual in visuals)
        {
            if (visual.animatronicID == animatronicId)
            {
                visual.visualAnimatronic.SetActive(false);
            }
        }
        actualAnimatronicsInRoom.Remove(animatronicId);
    }
}

[System.Serializable]
public struct TranslationInformation
{
    public AnimatronicID animatronicID;
    public Room targetRoom;
}

[System.Serializable]
public struct VisualInformation
{
    public AnimatronicID animatronicID;
    public GameObject visualAnimatronic;
}