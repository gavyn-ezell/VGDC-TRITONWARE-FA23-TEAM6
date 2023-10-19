using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject health;
    public float movementSpeed = 5;
    public Rigidbody2D player;
    private Vector2 movementDirection;
    public Animator changeDirection;
    //void Start()
    //{

    //}
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        movementDirection.y = Input.GetAxisRaw("Vertical");
        //Flip();
        changeDirection.SetFloat("Change Player Direction", movementDirection.x);
        changeDirection.SetFloat("Speed", movementDirection.sqrMagnitude);
    }

    void FixedUpdate()
    {
        player.MovePosition(player.position + movementDirection.normalized * movementSpeed * Time.fixedDeltaTime);
        //horizontal = Input.GetAxisRaw("Horizontal");
    }

    //private void Flip()
    //{
    //    if(facingRight && horizontal < 0 || facingRight && horizontal > 0)
    //    {
    //        facingRight = !facingRight;
    //        Vector3 localScale = transform.localScale;
    //        localScale.x *= -1;
    //        transform.localScale = localScale;
    //    }
    //}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Damage" || col.gameObject.tag == "Boss")
        {
            if(col.gameObject.tag == "Damage")
            {
                Destroy(col.gameObject);
            }
            --health.GetComponent<Health>().playerHealth;
        }
    }
}
