using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ramdisassembly : MonoBehaviour
{
    private bool[] ramstates = new bool[4];
    public UnityEvent rams;

    private void Update()
    {
        // Check if all rams are active
        bool allramsactive = true;
        foreach (bool state in ramstates)
        {
            if (!state)
            {
                allramsactive = false;
                break;
            }
        }

        // Invoke the event if all rams are active
        if (allramsactive)
        {
            rams.Invoke();
        }
    }

    // For hover enter
    public void SetramState(int ramIndex, bool state)
    {
        if (ramIndex >= 0 && ramIndex < ramstates.Length)
        {
            ramstates[ramIndex] = state;
        }
    }

    // These methods are for hover enter and exit and will be called from the Unity Editor
    public void ram01Enter() { SetramState(0, true); }
    public void ram02Enter() { SetramState(1, true); }
    public void ram03Enter() { SetramState(2, true); }
    public void ram04Enter() { SetramState(3, true); }
}
