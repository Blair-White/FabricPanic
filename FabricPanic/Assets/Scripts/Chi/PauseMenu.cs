using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    bool GamePaused;
   
    void Start()
    {
        GamePaused = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (GamePaused)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        GamePaused = true;
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 0f;
        GamePaused = false;
    }
}
