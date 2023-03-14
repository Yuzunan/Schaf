using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    private string color;
    public SpriteRenderer spriteRenderer;
    public Sprite[] SpriteArray;
    private int index;
    private void Start()
    {
        color = "Red";
        this.tag = color;
        index = 0;
        spriteRenderer.sprite = SpriteArray[index];
    }

    public void Update()
    {
        if (Time.timeScale != 0)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && color != "Red")
            {
                color = "Red";
                index = 0;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && color != "Green")
            {
                color = "Green";
                index = 1;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && color != "Orange")
            {
                color = "Orange";
                index = 2;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4) && color != "Blue")
            {
                color = "Blue";
                index = 3;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5) && color != "Yellow")
            {
                color = "Yellow";
                index = 4;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6) && color != "Purple")
            {
                color = "Purple";
                index = 5;
            }
        }

        if (!this.CompareTag(color))
        {
            this.tag = color;
            spriteRenderer.sprite = SpriteArray[index];
        }
    }
}