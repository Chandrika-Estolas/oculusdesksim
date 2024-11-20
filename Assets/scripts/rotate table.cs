using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatetable : MonoBehaviour
{
    public GameObject platform;
    public GameObject platform1;
    public void AddRotation()
    {
        Vector3 rotation = platform.transform.rotation.eulerAngles;
        rotation.z += 20f;
        platform.transform.rotation = Quaternion.Euler(rotation);

        Vector3 rotation1 = platform1.transform.rotation.eulerAngles;
        rotation1.z += 20f;
        platform1.transform.rotation = Quaternion.Euler(rotation1);
    }

    public void SubtractRotation()
    {
        Vector3 rotation = platform.transform.rotation.eulerAngles;
        rotation.z -= 20f;
        platform.transform.rotation = Quaternion.Euler(rotation);

        Vector3 rotation1 = platform1.transform.rotation.eulerAngles;
        rotation1.z -= 20f;
        platform1.transform.rotation = Quaternion.Euler(rotation1);

    }
}
