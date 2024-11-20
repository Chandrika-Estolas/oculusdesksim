using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class fanscript1 : MonoBehaviour
{
    private bool[] fanStates1 = new bool[5];
    public UnityEvent fans;

    private void Update()
    {
        // Check if all fans are active
        bool allFansActive = true;
        foreach (bool state in fanStates1)
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
    public void SetFanStates(int fanIndex, bool state)
    {
        if (fanIndex >= 0 && fanIndex < fanStates1.Length)
        {
            fanStates1[fanIndex] = state;
        }
    }

    // These methods are for hover enter and exit and will be called from the Unity Editor
    public void Fan01Enter() { SetFanStates(0, true); }
    public void Fan02Enter() { SetFanStates(1, true); }
    public void Fan03Enter() { SetFanStates(2, true); }
    public void Fan04Enter() { SetFanStates(3, true); }
    public void Fan05Enter() { SetFanStates(4, true); }

    public void Fan01Exit() { SetFanStates(0, false); }
    public void Fan02Exit() { SetFanStates(1, false); }
    public void Fan03Exit() { SetFanStates(2, false); }
    public void Fan04Exit() { SetFanStates(3, false); }
    public void Fan05Exit() { SetFanStates(4, false); }
}
