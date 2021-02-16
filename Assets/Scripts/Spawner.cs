using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //List of bad guys
    public List<GameObject> enemyShips = new List<GameObject>();

    [SerializeField]
    private GameObject enemyShip;

    [SerializeField, Tooltip("Time between each enemy spawn")]
    protected float spawnTime = 5f;

    [SerializeField, Tooltip("How fast enemy ships spawn")]
    protected float spawnRate = 0f;

    [SerializeField, Tooltip("Spawn enemy ships along x axis at random")]
    protected float randomX;

    public GameObject SpawnEnemies()
    {
        if (Time.time > spawnTime)
        {
            spawnTime = Time.time + spawnRate;
            randomX = Random.Range(-10f, 10f); //x axis left and right
            Vector2 spawnPoint = new Vector2(randomX, transform.position.y);
            Instantiate(enemyShip, spawnPoint, Quaternion.identity);
        }

        return enemyShip;
    }
}
