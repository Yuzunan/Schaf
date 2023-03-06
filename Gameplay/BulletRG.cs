using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRG : MonoBehaviour
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

        if (!this.CompareTag(color))
        {
            this.tag = color;
            spriteRenderer.sprite = SpriteArray[index];
        }
    }
}