using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Netcode;

public class PlayerHealthMult : NetworkBehaviour
{
    private float health = 0f;
    [SerializeField] private float maxhealth = 3f;
    public SpriteRenderer spriteRenderer;
    public Sprite DeadSprite;
    public Sprite OneLifeSprite;
    public Sprite TwoLifeSprite;
    public Sprite ThreeLifeSprite;
    private void Start()
    {
        health = maxhealth;
        SetNumberTextClientRpc(health);
    }

    public void UpdateHealth(float mod)
    {
        health -= mod;
        SetNumberTextClientRpc(health);
        if (health <= 0f)
        {
            health = 0f;
            Debug.Log("Player is Dead");
        }
    }
    
    
    [ClientRpc]
    public void SetNumberTextClientRpc(float value)
    {
        if (value <= 0)
            spriteRenderer.sprite = DeadSprite;
        else if (value == 1f)
            spriteRenderer.sprite = OneLifeSprite;
        else if (value == 2f)
            spriteRenderer.sprite = TwoLifeSprite;
        else
            spriteRenderer.sprite = ThreeLifeSprite;
    }
    
}
