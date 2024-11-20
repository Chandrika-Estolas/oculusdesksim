using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using System.Linq; 

public class methodforbtn : MonoBehaviour
{
    public List<GameObject> panels;
    public List<GameObject> parts;
    private int activatedIndexpanels = -1;
    private int activatedIndexparts = -1;

    private void Update()
    {
        GameObject activatedObject = panels.FirstOrDefault(obj => obj.activeSelf);
        if (activatedObject != null)
        {
            activatedIndexpanels = panels.IndexOf(activatedObject);
        }
        GameObject activatedparts = parts.FirstOrDefault(prt => prt.activeSelf);
        if (activatedparts != null)
        {
            activatedIndexparts = parts.IndexOf(activatedparts);
        }
    }

        public void RCallpress()
    {
        Debug.Log("rPRESSED");
    }
    public void RCallrelease()
    {
        Debug.Log("rRELEASED");
        if (activatedIndexpanels < panels.Count)
        {
            panels[activatedIndexpanels].SetActive(false);
            panels[activatedIndexpanels + 1].SetActive(true);
            activatedIndexpanels++; 
        }
        if (activatedIndexparts < parts.Count)
        {
            parts[activatedIndexparts].SetActive(false);
            parts[activatedIndexparts + 1].SetActive(true);
            activatedIndexparts++;
        }


    }
    public void LCallpress()
    {
        Debug.Log("lPRESSED");
    }
    public void LCallrelease()
    {
        Debug.Log("lRELEASED");
        if (activatedIndexpanels != 0)
        {
            panels[activatedIndexpanels].SetActive(false);
            panels[activatedIndexpanels - 1].SetActive(true);
            activatedIndexpanels--;
        }
        if (activatedIndexparts != 0)
        {
            parts[activatedIndexparts].SetActive(false);
            parts[activatedIndexparts - 1].SetActive(true);
            activatedIndexparts--;
        }
    }
}
