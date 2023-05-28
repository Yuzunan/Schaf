using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManagerMult : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    public TextMeshProUGUI restartText;
    [SerializeField] private GameObject pausePanel;
    private bool isGameOver = false;
    [SerializeField] private GameObject winPanel;
    public Sprite deadSprite;
    public Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        restartText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerHealthMult>().spriteRenderer.sprite == deadSprite)
        {
            isGameOver = true;
            StartCoroutine(GameOverSequence());
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isGameOver)
            {
                Time.timeScale = 0;
                pausePanel.SetActive(true);
            }
        }
        if (isGameOver ^ winPanel.activeSelf)
        {
            
            //If R is hit, restart the current scene
            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            //If Q is hit, quit the game
            if (Input.GetKeyDown(KeyCode.T))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(0);
            }
        }
        
        IEnumerator GameOverSequence()
        {
            gameOverPanel.SetActive(true);
        
            yield return new WaitForSeconds(3.0f);

            restartText.gameObject.SetActive(true);
            
            Time.timeScale = 0;
        }
    }
}
