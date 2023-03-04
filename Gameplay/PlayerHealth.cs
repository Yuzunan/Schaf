using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float health = 0f;
    [SerializeField] private float maxhealth = 3f;

    private void Start()
    {
        health = maxhealth;
    }

    public void UpdateHealth(float mod)
    {
        health -= mod;
        if (health <= 0f)
        {
            health = 0f;
            Debug.Log("Player is Dead");
        }
    }
    
}
