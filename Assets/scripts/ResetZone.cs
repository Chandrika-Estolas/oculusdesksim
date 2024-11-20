using UnityEngine;

public class ResetZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has the 'ResettableObject' script attached
        ResettableObject resettable = other.GetComponent<ResettableObject>();
        if (resettable != null)
        {
            // Reset the position of the object
            resettable.ResetPosition();
        }
    }
}
