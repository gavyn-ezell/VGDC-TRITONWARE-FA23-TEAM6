using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Health : MonoBehaviour
{
    public GameObject player;
    public Text healthText;
    public int playerHealth;

    public GameObject deathScreen;
    public GameObject deathRaccoon;

    public Image playerHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        deathScreen.SetActive(false);
        deathRaccoon.SetActive(false);
        playerHealth = 5;
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthBar.fillAmount = playerHealth / 5f;
        // if (player != null)
        // {
        //     healthText.text = "Health: " + playerHealth.ToString();
        // }
        // else
        // {
        //     healthText.text = "Health: " + 0;
        // }

        if (playerHealth < 1)
        {
            deathScreen.GetComponentInChildren<TMP_Text>().text = "YOU LOST!";
            deathScreen.SetActive(true);
            deathRaccoon.SetActive(true);
            Destroy(player);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
