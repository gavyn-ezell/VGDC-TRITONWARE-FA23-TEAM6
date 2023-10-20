using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject health;
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
            for(int i = 0; i < 1; i++)
            {
                Instantiate(bullet, transform.position, Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 0, 90) - Vector3.forward * Random.Range(80, 100)));
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
                for (int i = 0; i < 8; i++)
                {
                    Instantiate(bullet, transform.position, Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 0, 90) - Vector3.forward * Random.Range(40, 140)));
                }
            }
            else
            {
                rb.velocity = Vector2.Scale(rb.velocity, new Vector2(1f, -1f));
            }
        }
        if (col.gameObject.tag == "PlayerBullet")
        {
            Destroy(col.gameObject);
            --health.GetComponent<BossHealth>().bossHealth;
        }
    }
}
