using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class radfans : MonoBehaviour
{
    private bool[] coolingStates = new bool[7];
    public UnityEvent allCoolingComponentsActive;

    private void Update()
    {
        // Check if all cooling components are active
        bool allCoolingActive = true;
        foreach (bool state in coolingStates)
        {
            if (!state)
            {
                allCoolingActive = false;
                break;
            }
        }

        // Invoke the event if all cooling components are active
        if (allCoolingActive)
        {
            allCoolingComponentsActive.Invoke();
        }
    }

    // Method to set the state of a cooling component
    public void SetCoolingState(int coolingIndex, bool state)
    {
        if (coolingIndex >= 0 && coolingIndex < coolingStates.Length)
        {
            coolingStates[coolingIndex] = state;
        }
    }

    // Methods for hover enter events, to be called from the Unity Editor
    public void RadiatorEnter() { SetCoolingState(0, true); }
    public void Fan01Enter() { SetCoolingState(1, true); }
    public void Fan02Enter() { SetCoolingState(2, true); }
    public void Fan03Enter() { SetCoolingState(3, true); }
    public void Fan04Enter() { SetCoolingState(4, true); }
    public void Fan05Enter() { SetCoolingState(5, true); }
    public void Fan06Enter() { SetCoolingState(6, true); }

    // Methods for hover exit events, to be called from the Unity Editor
    public void RadiatorExit() { SetCoolingState(0, false); }
    public void Fan01Exit() { SetCoolingState(1, false); }
    public void Fan02Exit() { SetCoolingState(2, false); }
    public void Fan03Exit() { SetCoolingState(3, false); }
    public void Fan04Exit() { SetCoolingState(4, false); }
    public void Fan05Exit() { SetCoolingState(5, false); }
    public void Fan06Exit() { SetCoolingState(6, false); }
}
