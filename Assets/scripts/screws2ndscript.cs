using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class screws2ndscript : MonoBehaviour
{
    public GameObject[] screws;
    public UnityEvent screwsevent;

    private void Update()
    {
        // Check if all screws are active
        bool allActive = true;
        foreach (GameObject obj in screws)
        {
            if (!obj.activeInHierarchy)
            {
                allActive = false;
                break; // Exit the loop early since we found an inactive object
            }
        }

        // Invoke the event if all screws are active
        if (allActive)
        {
            screwsevent.Invoke();
        }
    }
}
