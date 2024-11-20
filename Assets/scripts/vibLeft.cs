using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

public class vibLeft : MonoBehaviour
{
    // Define GameObjects for collision detection
    public GameObject ObjectCollideLeftPinky;
    public GameObject ObjectCollideLeftRing;
    public GameObject ObjectCollideLeftMiddle;
    public GameObject ObjectCollideLeftIndex;
    public GameObject ObjectCollideLeftThumb;

    // Define the serial port
    SerialPort portNo;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the serial port
        portNo = new SerialPort("COM8", 9600);
        portNo.ReadTimeout = 5000;
        try
        {
            portNo.Open();
            Debug.Log("Serial port opened successfully.");
        }
        catch (UnauthorizedAccessException e)
        {
            Debug.LogError("UnauthorizedAccessException: " + e.Message);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object matches each specific GameObject
        if (other.gameObject == ObjectCollideLeftPinky)
        {
            TurnOnVibration("1");
        }
        else if (other.gameObject == ObjectCollideLeftRing)
        {
            TurnOnVibration("2");
        }
        else if (other.gameObject == ObjectCollideLeftMiddle)
        {
            TurnOnVibration("3");
        }
        else if (other.gameObject == ObjectCollideLeftIndex)
        {
            TurnOnVibration("4");
        }
        else if (other.gameObject == ObjectCollideLeftThumb)
        {
            TurnOnVibration("5");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Turn off vibration when exiting the trigger
        TurnOffVibration();
    }

    private void TurnOnVibration(string command)
    {
        // Write the command to the serial port
        if (portNo != null && portNo.IsOpen)
        {
            portNo.Write(command);
            Debug.Log("Vibration turned on: " + command);
        }
        else
        {
            Debug.LogError("Serial port is not open.");
        }
    }

    private void TurnOffVibration()
    {
        // Write the command to turn off vibration to the serial port
        if (portNo != null && portNo.IsOpen)
        {
            portNo.Write("0");
            Debug.Log("Vibration turned off.");
        }
        else
        {
            Debug.LogError("Serial port is not open.");
        }
    }

    // Close the serial port when the script is disabled or destroyed
    private void OnDestroy()
    {
        if (portNo != null && portNo.IsOpen)
        {
            portNo.Close();
            Debug.Log("Serial port closed.");
        }
    }
}