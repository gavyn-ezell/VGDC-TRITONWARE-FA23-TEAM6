using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float movementSpeed = 10;
    public Rigidbody2D player;
    private Vector2 movementDirection;
    public bool rightFacing;
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        movementDirection.y = Input.GetAxisRaw("Vertical");
        if(Input.GetAxisRaw("Horizontal") > 0.5)
        {
            if(rightFacing == true)
            {
                rightFacing = false;
                transform.Rotate(0f, 180f, 0f);
            }
        }
        if (Input.GetAxisRaw("Horizontal") < -0.5)
        {
            if (rightFacing != true)
            {
                rightFacing = true;
                transform.Rotate(0f, 180f, 0f);
            }
        }
      
    }

    void FixedUpdate()
    {
        player.MovePosition(player.position + movementDirection.normalized * movementSpeed * Time.fixedDeltaTime);
    }

}
