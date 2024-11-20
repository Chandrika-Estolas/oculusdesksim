using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class MoBo : MonoBehaviour
{
    public GameObject empty;
    public GameObject filler;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == empty)
        {
            filler.SetActive(true);
        }
    }
}
