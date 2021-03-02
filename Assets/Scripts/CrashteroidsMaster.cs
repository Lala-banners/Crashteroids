using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CrashteroidsMaster : MonoBehaviour
{
    private static CrashteroidsMaster crash;
    public Text scoreText;
    public float scoreCounter;

    [SerializeField]
    private Spawner spawner;

    [SerializeField]
    public Player player;

    public bool isGameOver = false;

    #region UI Elements
    public Text titleText;
    public Text gameOverText;
    public GameObject startGameButton;
    public GameObject retryButton;
    public GameObject playerShip;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        crash = this;
        isGameOver = false;
        playerShip.SetActive(false);
        Time.timeScale = 1;
        scoreText.enabled = true;
        scoreCounter = 0f;
    }

    public void StartGame()
    {
        crash.isGameOver = false;
        crash.titleText.enabled = false;
        crash.gameOverText.enabled = false;
        crash.startGameButton.SetActive(false);
        crash.retryButton.SetActive(false);
        crash.playerShip.SetActive(true);
    }

    public static void BadShipDestroyed()
    {
        crash.scoreCounter++;
        crash.scoreText.text = "Score: " + crash.scoreCounter;
    }

    public Spawner GetSpawner()
    {
        return crash.spawner.GetComponent<Spawner>();
    }

    public GameObject GetPlayerShip()
    {
        return crash.player.GetComponent<GameObject>();
    }

    public static void GameOver()
    {
        crash.gameOverText.enabled = true;
        crash.retryButton.SetActive(true);
        crash.isGameOver = true;
    }

    public void Retry()
    {
        crash.isGameOver = false;
        crash.titleText.enabled = false;
        crash.gameOverText.enabled = false;
        crash.startGameButton.SetActive(false);
        crash.retryButton.SetActive(false);
        crash.playerShip.SetActive(true);
        Time.timeScale = 1;
        SceneManager.LoadScene(0); //reload scene
    }
}
