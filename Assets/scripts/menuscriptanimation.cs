using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class menuscriptanimation : MonoBehaviour
{
    public UnityEvent eventformenu; 

    public void menuanim()
    {
        eventformenu.Invoke();
    }

}
