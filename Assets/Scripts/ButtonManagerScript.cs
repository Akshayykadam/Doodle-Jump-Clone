using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagerScript : MonoBehaviour
{
    //void Awake()
    //{
    //    DontDestroyOnLoad(gameObject);
    //}

    public void PlayButton()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
