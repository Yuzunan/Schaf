using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    public TextMeshProUGUI restartText;
    private bool isGameOver = false;
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
        if (player.GetComponent<PlayerHealth>().spriteRenderer.sprite == deadSprite)
        {
            isGameOver = true;
            StartCoroutine(GameOverSequence());
        }
        if (isGameOver)
        {
            
            //If R is hit, restart the current scene
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            //If Q is hit, quit the game
            if (Input.GetKeyDown(KeyCode.Q))
            {
                print("Application Quit");
                Application.Quit();
            }
        }
        
        IEnumerator GameOverSequence()
        {
            gameOverPanel.SetActive(true);
        
            yield return new WaitForSeconds(3.0f);

            restartText.gameObject.SetActive(true);
        }
    }
}
