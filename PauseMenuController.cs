using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{

    public GameObject PauseMenu;
    public bool IsPaused;

    // Start is called before the first frame update
    void Start()
    {
      Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsPaused)
            {
                IsPaused = false;
                PauseMenu.SetActive(false);
                Time.timeScale = 1f;
            } else
            {
                IsPaused = true;
                PauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }


    public void ResumeGame()
    {
        if(IsPaused)
        {
            IsPaused = false;
            PauseMenu.SetActive(false);
            Time.timeScale = 1f;
        } else
        {
            IsPaused = true;
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void RestartGame()
    {
      SceneManager.LoadScene("Bouncey Chords Proto");
      Time.timeScale = 1f;
    }

    public void OptionsMenu()
    {
        
    }

    public void ReturnToMainMenu()
    {
      Time.timeScale = 1f;  
      SceneManager.LoadScene("Main Menu");
    }

    public void ExitGame()
    {
      Debug.Log("QUIT!");
      Application.Quit();
    }
}

