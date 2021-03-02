using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    private Spawner spawner;
    [SerializeField] private float moveSpeed = 10f;
    private new SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        spawner = GetComponent<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveLazer();
    }

    public void MoveLazer()
    {
        //Make laser move
        transform.position += transform.up * moveSpeed * Time.deltaTime;

        if (!renderer.isVisible) //If the lazer disappears off screen, then destroy it 
        {
            Destroy(gameObject);
        }
    }

    // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Enemies>(out Enemies aliens))
        {
            CrashteroidsMaster.BadShipDestroyed(); //Update score
            spawner.enemyShips.Remove(collision.gameObject); //Remove alien ship from spawner
            Destroy(collision.gameObject); //Destroy enemy
            Destroy(gameObject); //Destroy laser
        }
    }


}
