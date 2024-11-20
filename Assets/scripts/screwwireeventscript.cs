using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class screwwireeventscript : MonoBehaviour
{
    public UnityEvent buttonactivate;
    public void OnAnimationEnd()
    {
        buttonactivate.Invoke();
    }
}
