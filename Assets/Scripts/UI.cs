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
    public Button startGameButton;
    #endregion

    #region UI Variables
    private float currentHighScore;
    public float score;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        currentHighScore = 0f;
        score = 0f;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartGame()
    {
        
    }

    public void GameOver()
    {

    }

    public void WinGame()
    {

    }
}
