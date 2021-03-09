using UnityEngine;

public class Lazer : MonoBehaviour
{
    //THIS WORKS!

    [SerializeField] private Spawner spawner;
    [SerializeField] private float moveSpeed = 10f;

    private void Update()
    {
        //Make laser move
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);

        if (transform.position.y > 10)
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
            Destroy(gameObject); //Destroy lazer
            spawner.enemyShips.Remove(collision.gameObject); //Remove enemy ship from list
            Destroy(collision.gameObject); //Destroy enemy ship
        }
    }
}
