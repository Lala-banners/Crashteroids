using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestScript
{
    //private Crashteroids crashGame;
     
    [UnityTest]
    public IEnumerator TestScriptWithEnumeratorPasses()
    {
        GameObject gameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));

        //Spawn asteroid
        //crashGame = gameObject.GetComponent<Crashteroids>();

        //Get access to spawner
        //Spawner spawner = crashGame.GetComponent<Crashteroids>();

        //GameObject asteroid = spawner.SpawnAsteroid();

        //Assert.Less(asteroid.transform.position.y, initialYPos);

        //Object.Destroy(crashGame.gameObject);

        yield return null;

    }
}
