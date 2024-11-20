using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class paste : MonoBehaviour
{
    public UnityEvent Tphaste;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "paste")
        {
            Tphaste.Invoke();
        }
    }
}
