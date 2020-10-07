using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public static int restartAttempts;
    public UnityAdsScript adsOnRestart;

    // Update is called once per frame
    public void PauseGame()
    {
        if (GameIsPaused)
        {
            Resume();
        }else
        {
            Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void RetryLevel()
    {
        // Game was freezing on restart because time scale hasnt been changed back to 1
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        restartAttempts++;
        if (restartAttempts == 10)
        {
            adsOnRestart.DisplayInterstitialAds();
            restartAttempts = 0;

            
            // Reset ad that plays after 5 levels to avoid another ad playing back to back
            if (gameManager.playAttempts == 4)
            {
                gameManager.playAttempts -= 2;
               
            }

        }
        
    }

    public void Mute()
    {
        FindObjectOfType<AudioManager>().Mute();
    }
}
