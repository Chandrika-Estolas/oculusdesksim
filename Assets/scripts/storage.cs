using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class storage : MonoBehaviour
{
    private bool[] storageStates = new bool[2];
    public UnityEvent allStorageDevicesActive;

    private void Update()
    {
        // Check if both storage devices are active
        bool allStorageActive = true;
        foreach (bool state in storageStates)
        {
            if (!state)
            {
                allStorageActive = false;
                break;
            }
        }

        // Invoke the event if both storage devices are active
        if (allStorageActive)
        {
            allStorageDevicesActive.Invoke();
        }
    }

    // Method to set the state of a storage device
    public void SetStorageState(int storageIndex, bool state)
    {
        if (storageIndex >= 0 && storageIndex < storageStates.Length)
        {
            storageStates[storageIndex] = state;
        }
    }

    // Methods for hover enter events, to be called from the Unity Editor
    public void SSDEnter() { SetStorageState(0, true); }
    public void mSSDEnter() { SetStorageState(1, true); }

    // Methods for hover exit events, to be called from the Unity Editor
    public void SSDExit() { SetStorageState(0, false); }
    public void mSSDExit() { SetStorageState(1, false); }
}
