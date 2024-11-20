using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class nextbutton : MonoBehaviour
{
    public List<GameObject> panels;
    int currentpanel = 0;
    public GameObject disable;
    public void NextPanel()
    {
        for (int i = currentpanel; i < panels.Count; i += 1)
        {
            panels[i].SetActive(true);
        }

    }
}
