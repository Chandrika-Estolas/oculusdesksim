using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class thermalpaste : MonoBehaviour
{
    public GameObject thermalp;
    public UnityEvent paste; 
    private void OnCollisionEnter(Collision col)
    { 
        if (col.gameObject == thermalp)
        {
            paste.Invoke();
        }
    }
}
