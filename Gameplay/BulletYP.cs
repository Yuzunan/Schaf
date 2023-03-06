using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletYP : MonoBehaviour
{
    private string color;
    public SpriteRenderer spriteRenderer;
    public Sprite[] SpriteArray;
    private int index;
    private void Start()
    {
        color = "Yellow";
        this.tag = color;
        index = 0;
        spriteRenderer.sprite = SpriteArray[index];
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5) && color != "Yellow")
        {
            color = "Yellow";
            index = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6) && color != "Purple")
        {
            color = "Purple";
            index = 1;
        }
        if (!this.CompareTag(color))
        {
            this.tag = color;
            spriteRenderer.sprite = SpriteArray[index];
        }
    }
}