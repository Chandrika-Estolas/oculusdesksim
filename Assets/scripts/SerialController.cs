using UnityEngine;
using System.IO.Ports;

public class SerialController : MonoBehaviour
{
    SerialPort serialPort;
    public string portName = "COM8"; // Change this to your Arduino port
    public int baudRate = 9600;

    void Start()
    {
        OpenPort();
    }

    void Update()
    {
        // Check if the GameObject is touched or clicked
        if (Input.GetButtonDown("Fire1")) // Change "Fire1" to your input method
        {
            try
            {
                // Send '1' to Arduino to trigger vibration
                serialPort.Write("1");
            }
            catch (System.Exception e)
            {
                Debug.LogError("Exception: " + e.Message);
            }
        }
    }

    void OnDestroy()
    {
        ClosePort();
    }

    void OpenPort()
    {
        try
        {
            serialPort = new SerialPort(portName, baudRate);
            serialPort.Open();
        }
        catch (System.Exception e)
        {
            Debug.LogError("Exception: " + e.Message);
        }
    }

    void ClosePort()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            try
            {
                serialPort.Close();
            }
            catch (System.Exception e)
            {
                Debug.LogError("Exception: " + e.Message);
            }
        }
    }
}
