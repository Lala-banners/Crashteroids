using UnityEngine;

public class Lazer : MonoBehaviour
{
    //THIS WORKS!

    private Spawner spawner;
    [SerializeField] private float moveSpeed = 10f;
    private new SpriteRenderer renderer;



    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        spawner = GetComponent<Spawner>();
    }

    private void Update()
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
        if(collision.gameObject.GetComponent<Enemies>() != null)
        {
            CrashteroidsMaster.BadShipDestroyed(); //Update score
            spawner.enemyShips.Remove(collision.gameObject); //Remove alien ship from spawner
            Destroy(collision.gameObject); //Destroy enemy
            Destroy(gameObject); //Destroy laser
        }
    }
}
