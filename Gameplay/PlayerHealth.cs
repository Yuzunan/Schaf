using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    private float health = 0f;
    [SerializeField] private float maxhealth = 3f;
    public TextMeshProUGUI numbertext;
    private void Start()
    {
        health = maxhealth;
        SetNumberText(health);
    }

    public void UpdateHealth(float mod)
    {
        health -= mod;
        SetNumberText(health);
        if (health <= 0f)
        {
            health = 0f;
            Debug.Log("Player is Dead");
        }
    }
    


    public void SetNumberText(float value)
    {
        numbertext.text = value.ToString()+"♥";
    }
    
}
