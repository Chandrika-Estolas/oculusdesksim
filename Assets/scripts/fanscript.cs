using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class fanscript : MonoBehaviour
{
    private bool[] fanStates = new bool[4];
    public UnityEvent fans;

    private void Update()
    {
        // Check if all fans are active
        bool allFansActive = true;
        foreach (bool state in fanStates)
        {
            if (!state)
            {
                allFansActive = false;
                break;
            }
        }

        // Invoke the event if all fans are active
        if (allFansActive)
        {
            fans.Invoke();
        }
    }

    // For hover enter
    public void SetFanState(int fanIndex, bool state)
    {
        if (fanIndex >= 0 && fanIndex < fanStates.Length)
        {
            fanStates[fanIndex] = state;
        }
    }

    // These methods are for hover enter and exit and will be called from the Unity Editor
    public void Fan01Enter() { SetFanState(0, true); }
    public void Fan02Enter() { SetFanState(1, true); }
    public void Fan03Enter() { SetFanState(2, true); }
    public void Fan04Enter() { SetFanState(3, true); }

    public void Fan01Exit() { SetFanState(0, false); }
    public void Fan02Exit() { SetFanState(1, false); }
    public void Fan03Exit() { SetFanState(2, false); }
    public void Fan04Exit() { SetFanState(3, false); }
}
