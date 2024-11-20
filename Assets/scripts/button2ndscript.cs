using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button2ndscript : MonoBehaviour
{
    public GameObject left;
    public GameObject right;
    public GameObject lastactivepanel;
    public GameObject firstactivepanel;
    private void Update()
    {
        if (lastactivepanel.activeSelf == true )
        {
            right.SetActive(false);
        }
        else
        {
            right.SetActive(true);
        }
        if (firstactivepanel.activeSelf == true)
        {
            left.SetActive(false);
        }
        else
        {
            left.SetActive(true);
        }
    }
}
