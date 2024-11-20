using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class minicanvas : MonoBehaviour
{
    public GameObject one;
    public GameObject two;

    private void Update()
    {
        if(this.gameObject.activeSelf == true)
        {
            one.SetActive(true);
            two.SetActive(true) ;
        }
    }

}
