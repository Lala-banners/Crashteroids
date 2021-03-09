using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    #region Movement
    public Rigidbody rBody;
    private float moveSpeed = 20f;
    private float horizontal;
    private float vertical;
    #endregion

    #region Shooting
    [SerializeField] private GameObject laserPrefab;
    public Transform firePoint;
    public bool canShoot = true;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ShipFlight();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnLaser();
        }
    }

    public void ShootLaser()
    {
        StartCoroutine("Shoot");
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        GameObject laserShot = SpawnLaser();
        laserShot.transform.position = firePoint.position;
        yield return new WaitForSeconds(0.4f);
        canShoot = true;
    }

    /// <summary>
    /// Player movement 
    /// </summary>
    public void ShipFlight()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        rBody.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
    }

    public GameObject SpawnLaser()
    {
        GameObject newLaser = Instantiate(laserPrefab, firePoint.position, Quaternion.identity);
        newLaser.SetActive(true);
        return newLaser;
    }


}
