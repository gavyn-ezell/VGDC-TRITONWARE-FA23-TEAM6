using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public GameObject player;
    public Text healthText;
    public int playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            healthText.text = "Health: " + playerHealth.ToString();
        }
        else
        {
            healthText.text = "Health: " + 0;
        }

        if(playerHealth < 1)
        {
            Destroy(player);
        }
    }
}
