using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float duration = 10f;

    float timeAlive = 0;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = transform.InverseTransformDirection(rb.velocity);
        velocity.y = bulletSpeed;
        rb.velocity = transform.TransformDirection(velocity);

        timeAlive += Time.deltaTime;
        if (timeAlive > duration)
        {
            Destroy(this.gameObject);
        }
    }
}
