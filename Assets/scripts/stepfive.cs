using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class step5 : MonoBehaviour
{
    private bool[] componentStates = new bool[3];
    public UnityEvent allComponentsActive;

    private void Update()
    {
        // Check if all components are active
        bool allActive = true;
        foreach (bool state in componentStates)
        {
            if (!state)
            {
                allActive = false;
                break;
            }
        }

        // Invoke the event if all components are active
        if (allActive)
        {
            allComponentsActive.Invoke();
        }
    }

    // For hover enter
    public void SetComponentState(int componentIndex, bool state)
    {
        if (componentIndex >= 0 && componentIndex < componentStates.Length)
        {
            componentStates[componentIndex] = state;
        }
    }

    // These methods are for hover enter and exit and will be called from the Unity Editor
    public void PSUEnter() { SetComponentState(0, true); }
    public void SSDEnter() { SetComponentState(1, true); }
    public void MSSDEnter() { SetComponentState(2, true); }

    public void PSUExit() { SetComponentState(0, false); }
    public void SSDExit() { SetComponentState(1, false); }
    public void MSSDExit() { SetComponentState(2, false); }
}
