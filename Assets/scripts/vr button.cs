using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class vrbutton : MonoBehaviour
{
    public GameObject buttons;
    public UnityEvent OnPress;
    public UnityEvent OnRelease;
    GameObject presser;
    AudioSource sound;
    bool isPressed;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            buttons.transform.localPosition = new Vector3(0.206681266f, 0.500003636f, -0.00537091261f);
            presser = other.gameObject;
            OnPress.Invoke();
            sound.Play();
            isPressed = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == presser)
        {
            buttons.transform.localPosition = new Vector3(0.207000002f, 0.100000001f, -0.00999999978f);
            OnRelease.Invoke();
            isPressed = false;
        }
    }

}
