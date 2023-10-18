using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 bounds;
    void Start()
    {
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, bounds.x * -1, bounds.x);
        pos.y = Mathf.Clamp(pos.y, bounds.y * -1, bounds.y);
        transform.position = pos;
    }
}
