using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 mousePos;
    private Camera cam;
    private Rigidbody2D player;
    public float force;
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        player = GetComponent<Rigidbody2D>();
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mousePos - transform.position;
        player.velocity = new Vector2(dir.x, dir.y).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
