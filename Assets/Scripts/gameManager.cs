using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public bool gameHasEnded = false;
    public float restartDelay = 2f;

    static int playAttempts;

    public GameObject completeLevelUI;

    public GameObject gameOverUI;

    public characterController player;

    public CheckPoint checkPoint;

    public GameObject watchAdButton;

    public UnityAdsScript adsOnRestart;

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);

        playAttempts++;
        if (playAttempts == 2)
        {
            adsOnRestart.DisplayInterstitialAds();
            playAttempts = 0;
        }
    }

    void EndGameDelay()
    {
        

        if (checkPoint.firstCheckPointReached != true)
        {
            Debug.Log("No checkpoint was activated, disable watch ads button");
            gameOverUI.SetActive(true);
            watchAdButton.SetActive(false);
        } else
        {
            Debug.Log("Player reached atleast one checkpoint, show ad button");
            gameOverUI.SetActive(true);
        }

        // Check if first checkpoint was reached, if not disable rewarded ads button.
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            FindObjectOfType<AudioManager>().Play("playerLose");
            Debug.Log("DEAD");
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

}