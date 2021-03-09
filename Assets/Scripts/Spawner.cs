using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //List of bad guys
    public List<GameObject> enemyShips = new List<GameObject>();

    [SerializeField]
    private GameObject alien1;
    [SerializeField]
    private GameObject alien2;
    [SerializeField]
    private GameObject alien3;
    [SerializeField]
    private GameObject alien4;

    public void BeginSpawning()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(0.4f);

        SpawnEnemyShips();
        StartCoroutine("Spawn");
    }

    public GameObject SpawnEnemyShips()
    {
        int random = Random.Range(1, 5);
        GameObject aliens;
        switch (random)
        {
            case 1:
                aliens = Instantiate(alien1);
                break;
            case 2:
                aliens = Instantiate(alien2);
                break;
            case 3:
                aliens = Instantiate(alien3);
                break;
            case 4:
                aliens = Instantiate(alien4);
                break;
            default:
                aliens = Instantiate(alien1);
                break;
        }

        aliens.SetActive(true);
        float xPos = Random.Range(-11.0f, 11.0f);

        // Spawn asteroid just above top of screen at a random point along x-axis
        aliens.transform.position = new Vector3(xPos, 10.0f, 0);

        enemyShips.Add(aliens);

        return aliens;
    }

    public void ClearAsteroids()
    {
        foreach (GameObject aliens in enemyShips)
        {
            Destroy(aliens);
        }

        enemyShips.Clear();
    }

    public void StopSpawning()
    {
        StopCoroutine("Spawn");
    }
}
