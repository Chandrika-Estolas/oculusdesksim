using System;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class anothercameratest : MonoBehaviour
{
    public string ipAddress = "192.168.1.11"; // Raspberry Pi IP address
    public int port = 12345; // Raspberry Pi port number

    private TcpClient client;
    private NetworkStream stream;
    private byte[] buffer = new byte[1024];

    // Variables for gyroscope data
    private float gyroX;
    private float gyroY;
    private float gyroZ;

    // Variables to store the initial rotation
    private Quaternion initialRotation;

    void Start()
    {
        try
        {
            client = new TcpClient(ipAddress, port);
            stream = client.GetStream();
            Debug.Log("Connected to Raspberry Pi");
            stream.BeginRead(buffer, 0, buffer.Length, OnDataReceived, null);

            // Store the initial rotation
            initialRotation = transform.rotation;
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to connect to Raspberry Pi: " + e.Message);
        }
    }

    void OnDataReceived(IAsyncResult result)
    {
        try
        {
            int bytesRead = stream.EndRead(result);
            string data = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            string[] values = data.Split(',');

            if (values.Length == 3)
            {
                float newGyroX = float.Parse(values[1]);
                float newGyroY = float.Parse(values[0]);
                float newGyroZ = float.Parse(values[2]);

                // Update gyro values
                gyroX = newGyroX;
                gyroY = newGyroY;
                gyroZ = newGyroZ;

                // Apply rotation
                MainThreadDispatcher.Enqueue(() => RotateCamera(gyroX, gyroY, gyroZ));
            }

            stream.BeginRead(buffer, 0, buffer.Length, OnDataReceived, null);
        }
        catch (Exception e)
        {
            Debug.LogError("Error reading data from Raspberry Pi: " + e.Message);
        }
    }

    void RotateCamera(float x, float y, float z)
    {
        // Adjust rotation speed factor
        float rotationSpeed = 0.1f; // Adjust as needed

        // Create a rotation based on gyroscope data
        Quaternion rotationX = Quaternion.Euler(x * rotationSpeed * Time.deltaTime, 0, 0);
        Quaternion rotationY = Quaternion.Euler(0, y * rotationSpeed * Time.deltaTime, 0);
        Quaternion rotationZ = Quaternion.Euler(0, 0, z * rotationSpeed * Time.deltaTime);

        // Apply the rotations relative to the current rotation
        transform.rotation = transform.rotation * rotationY * rotationX * rotationZ;
    }

    void OnDestroy()
    {
        if (stream != null)
            stream.Close();
        if (client != null)
            client.Close();
    }
}
