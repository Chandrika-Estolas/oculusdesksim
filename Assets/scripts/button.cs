using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{
    public float deadtime = 1.0f;
    private bool deadtimeactive = false;
    public UnityEvent OnPressed;
    public UnityEvent OnReleased;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "button" && !deadtimeactive)
        {
            //Debug.Log("PRESSED");
            OnPressed.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "button" && !deadtimeactive)
        {
            Debug.Log("RELEASED");
            OnReleased.Invoke();
            StartCoroutine(WaitForDeadTime());
            
        }
    }
    IEnumerator WaitForDeadTime()
    {
        deadtimeactive = true;
        yield return new WaitForSeconds(deadtime);
        deadtimeactive = false;
    
    }


}
