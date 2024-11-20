using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assemblycanvasscript : MonoBehaviour
{
    public GameObject canvas; 
    public void Update()
    {
        if (this.gameObject.activeSelf == true)
        {
            canvas.SetActive(true);
        }
    }
}
