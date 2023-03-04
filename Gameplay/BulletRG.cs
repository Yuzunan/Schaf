using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRG : MonoBehaviour
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
        if (!this.CompareTag(color))
            this.tag = color;
    }
}