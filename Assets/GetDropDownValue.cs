using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GetDropDownValue : MonoBehaviour
{
    public TMP_Dropdown dropdown;

    public void Update()
    {
        string dropdowntext = dropdown.captionText.text;
        Debug.Log(dropdowntext);
    }
}
