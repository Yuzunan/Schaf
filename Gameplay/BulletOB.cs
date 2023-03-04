using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOB : MonoBehaviour
{
    private string color;
    private void Start()
    {
        color = "Orange";
        this.tag = color;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3) && color != "Orange")
            color = "Orange";
        else if (Input.GetKeyDown(KeyCode.Alpha4) && color != "Blue")
            color = "Blue";
        if (!this.CompareTag(color))
            this.tag = color;
    }
}