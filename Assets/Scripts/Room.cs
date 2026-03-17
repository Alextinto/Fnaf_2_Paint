using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [Header("Initial Settings")]
    
    public string roomID;
    public Camera roomCamera;
    public Light roomLight;

    [SerializeField] List<VisualInformation> visuals;
    [SerializeField] List<TranslationInformation> translations;
    [SerializeField] bool canHoldMultipleAnimatronics = false;

    [Header("Runtime")]
    [SerializeField] List<AnimatronicID> actualAnimatronicsInRoom;

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

    [ContextMenu("Auto Fill ID")]
    private void AutoFillID()
    {
        roomID = gameObject.name;
    }

    [ContextMenu("Auto Fill Room and Light")]
    private void AutoFillRoomAndLight()
    {
        roomCamera = GetComponentInChildren<Camera>();
        roomLight = GetComponentInChildren<Light>();
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