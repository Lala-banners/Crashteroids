using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 5f;

    [SerializeField]
    private float maxY = -5;

    // Update is called once per frame
    void Update()
    {
        MoveBadGuys();
    }

    public void MoveBadGuys()
    {
        transform.Translate(Vector3.down * Time.deltaTime); 
    }

    //THIS WORKS YAY!
    // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider
    private void OnCollisionEnter(Collision collision)
    {
        //If enemies hit player ship then destroy the player ship
        if(collision.gameObject.GetComponent<Player>() != null) //if player ship exists
        {
            CrashteroidsMaster.GameOver();
            Destroy(collision.gameObject);
        }
        
        print("Player hit!");
    }


}
