using UnityEngine;

public class ResettableObject : MonoBehaviour
{
    public Vector3 initialPosition { get; private set; }

    void Start()
    {
        // Store the initial position of the GameObject
        initialPosition = transform.position;
    }

    public void ResetPosition()
    {
        // Reset the position to the initial position
        transform.position = initialPosition;
    }
}
