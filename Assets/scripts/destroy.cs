using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    public GameObject ToDestroy;
    public GameObject ToDestroy1;

    public void OnDestroy()
    {
        Destroy(ToDestroy);
        Destroy(ToDestroy1);

    }
}
