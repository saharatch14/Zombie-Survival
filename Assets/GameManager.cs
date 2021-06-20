using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public GameObject CompleteLevelUI;
    public GameObject bar;
    public GameObject mark;

    public float restartDelay = 1f;

    public void CompleteLevel()
    {
        mark.SetActive(false);
        bar.SetActive(false);
        CompleteLevelUI.SetActive(true);
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);
        }
        
    }
    void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
