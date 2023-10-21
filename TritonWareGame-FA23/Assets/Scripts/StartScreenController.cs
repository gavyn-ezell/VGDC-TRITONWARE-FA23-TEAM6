using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StartScreenController : MonoBehaviour
{
    public Animator fadeTransition;
    public UnityEngine.UI.Image fadeTransitionPanel;

    public void StartGame()
    {

        fadeTransitionPanel.raycastTarget = true;
        StartCoroutine(LoadLevel());
    }

    public void QuitGame()
    {
        Application.Quit();

    }

    IEnumerator LoadLevel()
    {

        fadeTransition.SetTrigger("CloseScene");
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("BossFight");
    }
}
