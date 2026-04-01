using UnityEngine;

public class AnimatronicPuppet : Animatronic
{
    [Header("Puppet")]
    //Diferent states of puppet, saved in animatronic because the map model limitations and puppet flow itself
    //0 - Closed, 1 - Slightly Open, 2 - Open, 3 - Empty
    [SerializeField] private GameObject[] puppetStates;

    protected override void Start()
    {
        base.Start();
        SetPuppetState(0);
    }

    private void SetPuppetState(int state)
    {
        for (int i = 0; i < puppetStates.Length; i++)
        {
            puppetStates[i].SetActive(i == state);
        }
    }


    #if UNITY_EDITOR
    [ContextMenu("Switch Puppet State")]
    private void SwitchPuppetState()
    {
        int currentState = 0;
        for (int i = 0; i < puppetStates.Length; i++)
        {
            if (puppetStates[i].activeSelf)
            {
                currentState = i;
                break;
            }
        }
        int nextState = (currentState + 1) % puppetStates.Length;
        SetPuppetState(nextState);
    }
    #endif
}
