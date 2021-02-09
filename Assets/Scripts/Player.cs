using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Movement
    public Rigidbody2D rb2D;
    private float moveSpeed = 20f;
    private float horizontal;
    private float vertical;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ShipFlight();
    }

    /// <summary>
    /// Player movement 
    /// </summary>
    public void ShipFlight()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        rb2D.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
    }
}
