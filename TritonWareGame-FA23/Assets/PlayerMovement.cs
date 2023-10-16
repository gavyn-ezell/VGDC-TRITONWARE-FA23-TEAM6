using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float movementSpeed;
    public Rigidbody2D player;

    private Vector2 movementDirection;
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        checkInputs();
    }

    void FixedUpdate()
    {
        movement();
    }

    void checkInputs()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        movementDirection = new Vector2(xAxis, yAxis).normalized;
    }

   void movement()
    {
        player.velocity = new Vector2(movementDirection.x * movementSpeed, movementDirection.y * movementSpeed);
    }
}
