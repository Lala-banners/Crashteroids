using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    #region UI Elements
    public TMP_Text titleText;
    public TMP_Text scoreText;
    public TMP_Text gameOverText;
    public GameObject startGameButton;
    public GameObject retryButton;
    public GameObject playerShip;
    #endregion

    #region UI Variables
    private float currentHighScore;
    public float scoreCounter;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        playerShip.SetActive(false);
        currentHighScore = 0f;
        scoreCounter = 0f;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        titleText.enabled = false;
        gameOverText.enabled = false;
        scoreText.enabled = true;
        startGameButton.SetActive(false);
        retryButton.SetActive(false);
        playerShip.SetActive(true);
    }

    public void GameOver()
    {
        gameOverText.enabled = true;
        retryButton.SetActive(true);
        scoreText.text = "Score: " + scoreCounter;
        Time.timeScale = 0;
    }

    public void WinGame()
    {

    }
}
