using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera cam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform trans;
    public bool test;
    public float coolDown = 20f;
    private float shootTimer;
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float aroundZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, aroundZ);

        if(test == false)
        {
            shootTimer += Time.deltaTime;
            if(shootTimer > coolDown)
            {
                test = true;
                shootTimer = 0;
            }
        }

        if(Input.GetMouseButton(0) && test == true)
        {
            Instantiate(bullet, trans.position, Quaternion.identity);
        }
    } 
}
