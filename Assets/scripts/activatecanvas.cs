using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activatecanvas : MonoBehaviour
{
    public GameObject canvas;

    private void Update()
    {
        if (this.gameObject.activeSelf == true)
        {
            canvas.SetActive(true);
        }
    }
}
