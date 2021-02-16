using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestScript
{
    private CrashteroidsMaster crashteroids;
     
    [SetUp]
    public void SetUp()
    {
        GameObject gameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));

        crashteroids = gameObject.GetComponent<CrashteroidsMaster>();
    }

    [TearDown]
    public void Teardown()
    {
        Object.Destroy(crashteroids.gameObject);
    }

    [UnityTest]
    public IEnumerator EnemiesMoveDown()
    {
        //Get access to spawner
        Spawner spawner = crashteroids.GetSpawner();
        GameObject enemyShip = spawner.SpawnEnemies();
        float initialYPos = enemyShip.transform.position.y;

        yield return new WaitForSeconds(0.1f);

        Assert.Less(crashteroids.transform.position.y, initialYPos);
        Object.Destroy(crashteroids.gameObject);
    }

    [UnityTest]
    public IEnumerator GameOverOnEnemyShipCollision()
    {
        Spawner spawner = crashteroids.GetSpawner();
        GameObject enemyShip = spawner.SpawnEnemies();

        GameObject playerShip = crashteroids.GetPlayerShip();
        enemyShip.transform.position = playerShip.transform.position;

        yield return new WaitForSeconds(0.1f);

        Assert.True(crashteroids.isGameOver);
    }

    [UnityTest]
    public IEnumerator LaserMovesUp()
    {
        //Spawn Laser
        //Assert.Greater(laser.transform);
        yield return null;

    }

    [UnityTest]
    public IEnumerator LaserDestroysEnemyShip()
    {
        //Spawn laser
        GameObject shipGO = crashteroids.GetPlayerShip();
        Player playerShip = shipGO.GetComponent<Player>();
        GameObject laser = playerShip.SpawnLaser();

        //Spawn Enemy Ship
        Spawner spawner = crashteroids.GetSpawner();
        GameObject enemyShip = spawner.SpawnEnemies();

        //Put laser on enemy ship
        laser.transform.position = enemyShip.transform.position;

        yield return new WaitForSeconds(0.1f);

        //We have to use the unity Assert.isNull because Unity deals with nulls differenetly to normal C#
        UnityEngine.Assertions.Assert.IsNull(enemyShip);
    }
}
