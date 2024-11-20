using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ssd : MonoBehaviour
{
    private bool ssd1, ssd2;
    public UnityEvent ssd12;

    public void Update()
    {
        if (ssd1 && ssd2 == true)
        {
            ssd12.Invoke();
        }
    }

    //for hover enter
    public void ssd11t()
    {
        ssd1 = true;

    }
    public void ssd12t()
    {
        ssd2 = true;

    }
    //for hover exit
    public void ssd11f()
    {
        ssd1 = false;

    }
    public void ssd12f()
    {
        ssd2 = false;

    }
}
