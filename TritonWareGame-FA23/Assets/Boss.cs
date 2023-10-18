using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public bool shoot;
    public bool bouncing;
    public GameObject bullet;
    GameObject player;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        shoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        rb.SetRotation(Mathf.Atan2(rb.position.y - player.transform.position.y, rb.position.x - player.transform.position.x) * Mathf.Rad2Deg + 90);

        if (shoot)
        {
            shoot = false;
            for(int i = 0; i < 3; i++)
            {
                Instantiate(bullet, transform.position, Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 0, 90) - Vector3.forward * Random.Range(70, 110)));
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(bouncing)
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
}
