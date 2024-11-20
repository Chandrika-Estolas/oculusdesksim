using UnityEngine;
using UnityEngine.Events;

public class ButtonPress : MonoBehaviour
{
    public UnityEvent onPressed;  // UnityEvent to be invoked when the button is pressed

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand"))  // Check if the colliding object has the "PlayerHand" tag
        {
            onPressed.Invoke();  // Invoke the onPressed event
        }
    }
}
