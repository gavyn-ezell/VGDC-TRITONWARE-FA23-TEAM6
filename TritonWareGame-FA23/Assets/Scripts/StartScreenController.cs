using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenController : MonoBehaviour
{
    // Update is called once per frame
    public void StartGame()
    {
        SceneManager.LoadScene("BossFight", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();

    }
}
