using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public GameObject boss;
    public Text healthText;
    public int bossHealth;

    // Start is called before the first frame update
    void Start()
    {
        bossHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (boss != null)
        {
            healthText.text = "Health: " + bossHealth.ToString();
        }
        else
        {
            healthText.text = "Health: " + 0;
        }

        if (bossHealth < 1)
        {
            Destroy(boss);
        }
    }
}
