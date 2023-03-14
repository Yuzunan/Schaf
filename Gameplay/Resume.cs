using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Pause()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
    }
    
    public void Restart()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}
