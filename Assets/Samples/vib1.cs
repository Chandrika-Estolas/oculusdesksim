using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;
using Debug = UnityEngine.Debug; // Define alias for UnityEngine.Debug

public class vib1 : MonoBehaviour
{
    public GameObject ObjectCollideLeftPinky;
    public GameObject ObjectCollideLeftRing;
    public GameObject ObjectCollideLeftMiddle;
    public GameObject ObjectCollideLeftIndex;
    public GameObject ObjectCollideLeftThumb;

    private SerialPort portNo;
    private Dictionary<GameObject, string> objectCommandMap;

    // Start is called before the first frame update
    void Start()
    {
        string portName = "COM3"; // Default port, can be changed
        portNo = new SerialPort(portName, 9600);
        portNo.ReadTimeout = 5000;
        try
        {
            portNo.Open();
            Debug.Log("Port opened successfully: " + portName);
        }
        catch (UnauthorizedAccessException e)
        {
            Debug.LogError("UnauthorizedAccessException: " + e.Message);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error opening port: " + e.Message);
        }

        objectCommandMap = new Dictionary<GameObject, string>
        {
            { ObjectCollideLeftPinky, "1" },
            { ObjectCollideLeftRing, "2" },
            { ObjectCollideLeftMiddle, "3" },
            { ObjectCollideLeftIndex, "4" },
            { ObjectCollideLeftThumb, "5" }
        };
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (portNo.IsOpen && objectCommandMap.TryGetValue(collision.gameObject, out string command))
        {
            portNo.Write(command);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (portNo.IsOpen && objectCommandMap.ContainsKey(collision.gameObject))
        {
            portNo.Write("0");
        }
    }

    private void OnApplicationQuit()
    {
        if (portNo != null && portNo.IsOpen)
        {
            portNo.Close();
        }
    }
}
