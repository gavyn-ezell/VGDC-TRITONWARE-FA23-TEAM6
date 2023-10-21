using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossHealth : MonoBehaviour
{
    public GameObject boss;
    public Text healthText;
    public int bossHealth = 100;

    public GameObject victoryScreen;
    public GameObject victoryRaccoon;

    // Start is called before the first frame update
    void Start()
    {
        victoryRaccoon.SetActive(false);
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
            victoryScreen.GetComponentInChildren<TMP_Text>().text = "YOU WON!";
            victoryScreen.SetActive(true);
            victoryRaccoon.SetActive(true);


            Destroy(boss);
        }
    }
}
