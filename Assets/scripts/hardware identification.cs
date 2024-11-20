using UnityEngine;

public class hardwareidentification : MonoBehaviour
{
    public GameObject targetObject; // The game object to check
    public GameObject objectToActivate; // The game object to activate
    public GameObject[] objectsToDeactivate; // The game objects to deactivate

    void Update()
    {
        // Check if the target object is active
        if (targetObject.activeInHierarchy)
        {
            // Activate the specified object
            objectToActivate.SetActive(true);

            // Deactivate all other specified objects
            foreach (GameObject obj in objectsToDeactivate)
            {
                if (obj != objectToActivate)
                {
                    obj.SetActive(false);
                }
            }
        }
        else
        {
            // Optionally, you can deactivate the objectToActivate if the targetObject is not active
            objectToActivate.SetActive(false);
        }
    }
}
