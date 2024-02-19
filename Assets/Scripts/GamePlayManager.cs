using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayManager : MonoBehaviour
{
    private static GamePlayManager instance;
    public static GamePlayManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GamePlayManager>();
                if (instance == null)
                {
                    Debug.LogError("GamePlayManager instance not found in the scene.");
                }
            }
            return instance;
        }
    }

    public GameObject GameOverPanel;

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
