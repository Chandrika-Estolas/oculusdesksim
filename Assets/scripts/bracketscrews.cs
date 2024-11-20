using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class bracketscrews : MonoBehaviour
{
    public GameObject[] bscrews;
    public UnityEvent bscrewsevent;


    private void Update()
    {
        foreach (GameObject obj in bscrews)
        {
            if (obj.activeSelf == false)
            {
                bscrewsevent.Invoke();
            }
        }
    }
}
