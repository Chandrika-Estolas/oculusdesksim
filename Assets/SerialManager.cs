using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;
using System.IO;
using TMPro;

public class SerialManager : MonoBehaviour
{
    // Singleton instance
    public static SerialManager Instance { get; private set; }

    // Serial ports for communication
    private SerialPort portNoRight;
    private SerialPort portNoLeft;



    private void Awake()
    {
        // Ensure only one instance exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeSerialPorts();
        }
        else
        {
            Destroy(gameObject);
        }


    }

    private void InitializeSerialPorts()
    {
        // Initialize the right hand serial port (COM6)
        try
        {
            portNoRight = new SerialPort("COM6", 9600);
            portNoRight.ReadTimeout = 5000;
            portNoRight.Open();
            Debug.Log("COM6 (Right) Port Opened");
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to open COM6 (Right): " + e.Message);
        }

        // Initialize the left hand serial port (COM3)
        try
        {
            portNoLeft = new SerialPort("COM3", 9600);
            portNoLeft.ReadTimeout = 5000;
            portNoLeft.Open();
            Debug.Log("COM3 (Left) Port Opened");
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to open COM3 (Left): " + e.Message);
        }
    }

    public void SendData(string data, int port)
    {
        try
        {
            if (port == 0 && portNoRight != null && portNoRight.IsOpen)
            {
                portNoRight.Write(data);
                Debug.Log("Sent to COM6 (Right): " + data);
            }
            else if (port == 1 && portNoLeft != null && portNoLeft.IsOpen)
            {
                portNoLeft.Write(data);
                Debug.Log("Sent to COM3 (Left): " + data);
            }
        }
        catch (InvalidOperationException e)
        {
            Debug.LogError("InvalidOperationException: " + e.Message);
        }
        catch (TimeoutException e)
        {
            Debug.LogError("TimeoutException: " + e.Message);
        }
        catch (Exception e)
        {
            Debug.LogError("Exception on write: " + e.Message);
        }
    }

    // Close the serial ports when the application quits
    private void OnApplicationQuit()
    {
        if (portNoRight != null && portNoRight.IsOpen)
        {
            portNoRight.Close();
            Debug.Log("COM6 (Right) Port Closed");
        }
        if (portNoLeft != null && portNoLeft.IsOpen)
        {
            portNoLeft.Close();
            Debug.Log("COM3 (Left) Port Closed");
        }
    }
}