using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletYP : MonoBehaviour
{
    private string color;
    private void Start()
    {
        color = "Yellow";
        this.tag = color;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5) && color != "Yellow")
            color = "Yellow";
        else if (Input.GetKeyDown(KeyCode.Alpha6) && color != "Purple")
            color = "Purple";
        if (!this.CompareTag(color))
            this.tag = color;
    }
}