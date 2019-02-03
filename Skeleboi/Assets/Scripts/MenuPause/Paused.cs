using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Paused : MonoBehaviour {

    public GameObject pauseMenu;
    public bool pause = false;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update ()
    {
        PauseGame();     
    }

    void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
        }

        if (pause)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else if (!pause)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void Resume()
    {
        pause = false;
    }

    public void Exit()
    {
        pause = false;
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
