using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public bool gameHasEnded = false;
    public float restartDelay = 2f;

    public static int playAttempts;

    public GameObject completeLevelUI;

    public GameObject gameOverUI;

    public characterController player;

    public CheckPoint checkPoint;

    public GameObject watchAdButton;

    public UnityAdsScript adsOnRestart;

    public GameObject pauseMenuUI;

    public GameObject checkpointButton;

    //public GameObject playerH;

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
        Time.timeScale = 0f;
        playAttempts++;
        if (playAttempts == 5)
        {
            adsOnRestart.DisplayInterstitialAds();
            playAttempts = 0;
        }
    }

    void EndGameDelay()
    {
        Time.timeScale = 0f;
        if (checkPoint.firstCheckPointReached != true)
        {
            Debug.Log("No checkpoint was activated, disable watch ads button");
            gameOverUI.SetActive(true);
            watchAdButton.SetActive(false);
            checkpointButton.SetActive(false);
        } else
        {
            Debug.Log("Player reached atleast one checkpoint, show ads button");
            gameOverUI.SetActive(true);
        }
        // Check if first checkpoint was reached, if not disable rewarded ads button.
    }

    void minusPlayerHealth()
    {
        GameObject playerH = GameObject.Find("pogo");

        playerH.GetComponent<playerCollision>().health -= 1;

        //playerH.GetComponent<playerCollision>().health -= 1;
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            FindObjectOfType<AudioManager>().Play("playerLose");
            Debug.Log("DEAD");
            minusPlayerHealth();
            Invoke("EndGameDelay", restartDelay);

        }
    }

    public void LevelComplete()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            
            Debug.Log("LEVEL COMPLETE");
            Invoke("CompleteLevel", restartDelay);
        }

    }

    void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }


    //private void OnApplicationFocus(bool focus)
    //{
    //    if (focus)
    //    {
    //        Debug.Log("Game is in focus");
    //        return; 
    //    }
    //    else
    //    {
    //        Debug.Log("game is out of focus");
    //        pauseMenuUI.SetActive(true);
    //        Time.timeScale = 0f;
    //    }
    //}

}