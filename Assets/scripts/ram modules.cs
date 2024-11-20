using UnityEngine;
using UnityEngine.Events;

public class rammodules : MonoBehaviour
{
    // Array of GameObjects to check
    public GameObject[] gameObjectsToCheck;

    // Event to invoke when all GameObjects are active
    public UnityEvent onAllObjectsActive;

    void Update()
    {
        // Check if all specified GameObjects are active
        if (AreAllObjectsActive())
        {
            // Invoke the event
            onAllObjectsActive.Invoke();

        }
    }

    bool AreAllObjectsActive()
    {
        foreach (GameObject obj in gameObjectsToCheck)
        {
            if (obj.activeSelf==false)
            {
                return false;
            }
        }
        return true;
    }
}
