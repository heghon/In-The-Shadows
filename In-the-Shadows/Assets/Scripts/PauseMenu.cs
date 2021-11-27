using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused;
    public GameObject PauseMenuUI;
    PlaceManager placeManager;

    void Start()
    {
        placeManager = GameObject.FindObjectOfType<PlaceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && placeManager.ActualPlace == "PlayPlace")
        {
            if (GameIsPaused)
            {
                ResumeTheGame();
            }
            else
            {
                PauseTheGame();
            }
        }
    }

    public void ResumeTheGame()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void PauseTheGame()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void GoToGameMenu()
    {

    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
