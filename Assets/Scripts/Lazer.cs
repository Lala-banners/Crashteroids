using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    Spawner spawner;

    [SerializeField]
    private float moveSpeed = 2f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Make laser move
        transform.position += transform.right * moveSpeed * Time.deltaTime;
    }

    // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Enemies>() != null)
        {
            CrashteroidsMaster.BadShipDestroyed();
            spawner.enemyShips.Remove(collision.gameObject);
            Destroy(collision.gameObject); //Destroy enemy
            Destroy(gameObject); //Destroy laser
        }
    }


}
