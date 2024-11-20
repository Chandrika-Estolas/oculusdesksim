using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class hardwareidentification1 : MonoBehaviour
{
    public GameObject toDestroy;

    private void Update()
    {
        if (this.gameObject.activeSelf == true)
        {
            toDestroy.SetActive(true);

        }
        else
        {
            toDestroy.SetActive(false);
        }
    }
}
