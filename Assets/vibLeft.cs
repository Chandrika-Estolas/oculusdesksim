using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibLeft : MonoBehaviour
{
    // Objects to detect collisions with
    public GameObject ObjectCollideLeftPinky;
    public GameObject ObjectCollideLeftRing;
    public GameObject ObjectCollideLeftMiddle;
    public GameObject ObjectCollideLeftIndex;
    public GameObject ObjectCollideLeftThumb;

    // Flags to ensure vibration occurs only once
    private bool isPinkyVibrating = false;
    private bool isRingVibrating = false;
    private bool isMiddleVibrating = false;
    private bool isIndexVibrating = false;
    private bool isThumbVibrating = false;

    private void OnTriggerEnter(Collider other)
    {
        HandleTriggerEvent(other, true);
    }

    private void OnTriggerExit(Collider other)
    {
        HandleTriggerEvent(other, false);
    }

    private void HandleTriggerEvent(Collider other, bool isEnter)
    {
        // Log the trigger event
        Debug.Log((isEnter ? "OnTriggerEnter" : "OnTriggerExit") + " called with: " + other.gameObject.name);

        if (isEnter)
        {
            if (other.gameObject == ObjectCollideLeftPinky && !isPinkyVibrating)
            {
                StartCoroutine(VibrateCoroutine("1", "6", "Pinky"));
            }
            else if (other.gameObject == ObjectCollideLeftRing && !isRingVibrating)
            {
                StartCoroutine(VibrateCoroutine("2", "7", "Ring"));
            }
            else if (other.gameObject == ObjectCollideLeftMiddle && !isMiddleVibrating)
            {
                StartCoroutine(VibrateCoroutine("3", "8", "Middle"));
            }
            else if (other.gameObject == ObjectCollideLeftIndex && !isIndexVibrating)
            {
                StartCoroutine(VibrateCoroutine("4", "9", "Index"));
            }
            else if (other.gameObject == ObjectCollideLeftThumb && !isThumbVibrating)
            {
                StartCoroutine(VibrateCoroutine("5", "A", "Thumb"));
            }
        }
    }

    private IEnumerator VibrateCoroutine(string startCommand, string stopCommand, string finger)
    {
        switch (finger)
        {
            case "Pinky":
                isPinkyVibrating = true;
                break;
            case "Ring":
                isRingVibrating = true;
                break;
            case "Middle":
                isMiddleVibrating = true;
                break;
            case "Index":
                isIndexVibrating = true;
                break;
            case "Thumb":
                isThumbVibrating = true;
                break;
        }

        SerialManager.Instance.SendData(startCommand, 1); // Use port 1 (COM3) for left hand
        Debug.Log("Sent: " + startCommand);

        yield return new WaitForSeconds(0.3f);

        SerialManager.Instance.SendData(stopCommand, 1); // Use port 1 (COM3) for left hand
        Debug.Log("Sent: " + stopCommand);

        switch (finger)
        {
            case "Pinky":
                isPinkyVibrating = false;
                break;
            case "Ring":
                isRingVibrating = false;
                break;
            case "Middle":
                isMiddleVibrating = false;
                break;
            case "Index":
                isIndexVibrating = false;
                break;
            case "Thumb":
                isThumbVibrating = false;
                break;
        }
    }
}