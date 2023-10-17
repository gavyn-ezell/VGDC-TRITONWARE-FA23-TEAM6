using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncescript : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody2D rb;
    public float movespeed = 5f;
    void Start()
    {
        //rb.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * movespeed;
        rb.velocity = new Vector2(-1f, 0.2f).normalized * movespeed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "l" || col.name == "r")
        {
            rb.velocity = Vector2.Scale(rb.velocity, new Vector2(-1f, 1f));
        }
        else
        {
            rb.velocity = Vector2.Scale(rb.velocity, new Vector2(1f, -1f));
        }
    }
}
