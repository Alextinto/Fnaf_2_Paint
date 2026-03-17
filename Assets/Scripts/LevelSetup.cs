using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSetup", menuName = "Scriptable Objects/LevelSetup")]
public class LevelSetup : ScriptableObject
{
    public List<AnimatronicSetup> animatronicSetups;
}

public class AnimatronicSetup
{
    public AnimatronicID animatronicID;
    public int difficultyLevel;
}
