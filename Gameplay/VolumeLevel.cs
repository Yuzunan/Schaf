using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeLevel : MonoBehaviour
{

    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject gameoverPanel;
    [SerializeField] private AudioClip Win;
    [SerializeField] private AudioClip GameOver;
    public AudioSource audioSource;
    void Start()
    {
        audioSource.volume = 1;
    }
 
    public void Update()
    {
        if (winPanel.activeSelf)
        {
            audioSource.clip = Win;
            if (audioSource.time <= 0)
            {
                audioSource.Play(0);
                audioSource.volume = 0.25f;
            }
                
        }
        else if (gameoverPanel.activeSelf)
        {
            audioSource.clip = GameOver;
            if (audioSource.time <= 0)
            {
                audioSource.Play(0);
                audioSource.volume = 0.25f;
            }
        }
    }
    
}