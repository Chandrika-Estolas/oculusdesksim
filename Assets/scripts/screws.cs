using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screws : MonoBehaviour
{
    public GameObject screwtoactivate;
    public GameObject screwtodeactivate;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "screwdriver")
        {
            screwtoactivate.SetActive(true);
            screwtodeactivate.SetActive(false);
        }
    }
}

