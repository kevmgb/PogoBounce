using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    static int restartAttempts;

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        restartAttempts++;
        if (restartAttempts == 10)
        {
            adsOnRestart.DisplayInterstitialAds();
            restartAttempts = 0;
        }
        
    }

    public void Mute()
    {
        FindObjectOfType<AudioManager>().Mute();
    }
}
