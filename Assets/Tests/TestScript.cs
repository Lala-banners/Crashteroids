using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

[TestFixture]
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

    //WORKING
    [UnityTest]
    public IEnumerator GameOverOnEnemyShipCollision()
    {
        GameObject asteroid = crashteroids.GetSpawner().SpawnEnemyShips();
        asteroid.transform.position = crashteroids.GetPlayerShip().transform.position;
        yield return new WaitForSeconds(0.1f);

        Assert.True(crashteroids.isGameOver);
    }

    //WORKING
    [UnityTest]
    public IEnumerator NewGameRestartsGame()
    {
        crashteroids.isGameOver = true;
        crashteroids.StartGame();

        Assert.False(crashteroids.isGameOver);

        yield return null;
    }

    //WORKING
    [UnityTest]
    public IEnumerator LaserMovesUp()
    {
        //Spawn Laser
        GameObject lazer = crashteroids.GetPlayerShip().SpawnLaser();
        float initialYPos = lazer.transform.position.y;
        yield return new WaitForSeconds(0.1f);

        Assert.Greater(lazer.transform.position.y, initialYPos);
    }

    //WORKING
    [UnityTest]
    public IEnumerator LaserDestroysEnemyShip()
    {
        //Spawn Enemy Ship
        GameObject alien = crashteroids.GetSpawner().SpawnEnemyShips();
        alien.transform.position = Vector3.zero;

        //Spawn laser
        GameObject lazer = crashteroids.GetPlayerShip().SpawnLaser();
        lazer.transform.position = Vector3.zero;
        yield return new WaitForSeconds(0.1f);

        UnityEngine.Assertions.Assert.IsNull(alien);
    }

    //WORKING
    [UnityTest]
    public IEnumerator UpdateScore()
    {
        GameObject alien = crashteroids.GetSpawner().SpawnEnemyShips();
        alien.transform.position = Vector3.zero;
        GameObject lazer = crashteroids.GetPlayerShip().SpawnLaser();
        lazer.transform.position = Vector3.zero;
        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(crashteroids.scoreCounter, 2.0f);
    }

    //WORKING
    [UnityTest]
    public IEnumerator EnemyShipsMoveDown()
    {
        GameObject alien = crashteroids.GetSpawner().SpawnEnemyShips();
        float initialYPos = alien.transform.position.y;
        yield return new WaitForSeconds(0.5f);

        Assert.Less(alien.transform.position.y, initialYPos);
    }
}
