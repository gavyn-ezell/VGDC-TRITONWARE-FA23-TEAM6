using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 screenBounds;
    private float objWidth;
    private float objHeight;
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        objWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, screenBounds.x * -1 + objWidth, screenBounds.x - objWidth);
        pos.y = Mathf.Clamp(pos.y, screenBounds.y * -1 + objHeight, screenBounds.y - objHeight);
        transform.position = pos;
    }
}
