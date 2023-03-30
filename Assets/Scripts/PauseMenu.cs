using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject Controls;
    public GameObject back;
    public GameObject resume;
    public GameObject options;
    public GameObject quit;
    public bool isPaused;
    // Start is called before the first frame update

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && !isPaused)
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
        back.SetActive(false);
    }

    public void Options()
    {
        resume.SetActive(false);
        options.SetActive(false);
        quit.SetActive(false);
        Controls.SetActive(true);
        back.SetActive(true);
    }

    public void Back()
    {
        resume.SetActive(true);
        options.SetActive(true);
        quit.SetActive(true);
        back.SetActive(false);
        Controls.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void Quit()
    {
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
        }
    }
}
