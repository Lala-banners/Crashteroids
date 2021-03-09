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
        titleText.enabled = true;
        gameOverText.enabled = false;
        scoreText.enabled = false;
        startGameButton.SetActive(true);
    }

    public void StartGame()
    {
        isGameOver = false;
        titleText.enabled = false;
        startGameButton.SetActive(false);
        scoreCounter = 0;
        scoreText.text = "Score: " + scoreCounter;
        scoreText.enabled = true;
        spawner.BeginSpawning();
        spawner.ClearAsteroids();
        gameOverText.enabled = false;
        playerShip.transform.position = new Vector3(0, -3.22f, 0);
        //playerShip.transform.eulerAngles = new Vector3(90, 180, 0);
    }

    public static void GameOver()
    {
        crash.titleText.enabled = true;
        crash.startGameButton.SetActive(true);
        crash.isGameOver = true;
        crash.spawner.StopSpawning();
        crash.gameOverText.enabled = true;
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

    public Player GetPlayerShip()
    {
        return player.GetComponent<Player>();
    }
}
