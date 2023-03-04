using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    private string color;
    private void Start()
    {
        color = "Red";
        this.tag = color;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && color != "Red")
            color = "Red";
        else if (Input.GetKeyDown(KeyCode.Alpha2) && color != "Green")
            color = "Green";
        else if (Input.GetKeyDown(KeyCode.Alpha3) && color != "Orange")
            color = "Orange";
        else if (Input.GetKeyDown(KeyCode.Alpha4) && color != "Blue")
            color = "Blue";
        else if (Input.GetKeyDown(KeyCode.Alpha5) && color != "Yellow")
            color = "Yellow";
        else if (Input.GetKeyDown(KeyCode.Alpha6) && color != "Purple")
            color = "Purple";
        if (!this.CompareTag(color))
            this.tag = color;
    }
}