using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOB : MonoBehaviour
{
    private string color;
    public SpriteRenderer spriteRenderer;
    public Sprite[] SpriteArray;
    private int index;
    private void Start()
    {
        color = "Orange";
        this.tag = color;
        index = 0;
        spriteRenderer.sprite = SpriteArray[index];
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3) && color != "Orange")
        {
            color = "Orange";
            index = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && color != "Blue")
        {
            color = "Blue";
            index = 1;
        }
        if (!this.CompareTag(color))
        {
            this.tag = color;
            spriteRenderer.sprite = SpriteArray[index];
        }
    }
}