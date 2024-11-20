using UnityEngine;

public class ToggleGameObject : MonoBehaviour
{
    public GameObject targetObject; // The GameObject to be toggled
    private bool isActive = false; // State tracking whether the target is active or not

    public void ToggleObject()
    {
        isActive = !isActive;
        targetObject.SetActive(isActive);
    }
}
