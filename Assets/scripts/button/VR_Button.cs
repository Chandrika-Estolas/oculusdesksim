using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class VR_Button : MonoBehaviour
{
    public float deadTime = 1.0f;
    private bool _deadTimeActive = false;
    public UnityEvent onPressed, onReleased;
    public int scenenumber;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "button" && !_deadTimeActive)
        {
            onReleased?.Invoke();
            Debug.Log("I have been released");
            SceneManager.LoadScene(scenenumber);
            StartCoroutine(WaitForDeadTime());
        }

        IEnumerator WaitForDeadTime()
        {
            _deadTimeActive = true;
            yield return new WaitForSeconds(deadTime);
            _deadTimeActive = false;
        }
    }
}
