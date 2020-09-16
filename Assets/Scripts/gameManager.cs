using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public bool gameHasEnded = false;
    public float restartDelay = 2f;
    public float fadeCheckpointText = 2f;

    // static int playAttempts;

    public GameObject completeLevelUI;

    public GameObject gameOverUI;

    public GameObject checkpointReachedUI;

    public characterController player;

    // public InterstitialAds adsOnRestart;

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);

        // playAttempts++;
        // if (playAttempts == 5)
        // {
            //adsOnRestart.DisplayInterstitialAds();
            // playAttempts = 0;
        // }
    }

    void EndGameDelay()
    {
        gameOverUI.SetActive(true);
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

    public void CheckPointReached()
    {
        checkpointReachedUI.SetActive(true);
        Debug.Log("Checkpoint Reached");
        Invoke("CheckpointReachedCloseMsg", fadeCheckpointText);
    }

    public void CheckpointReachedCloseMsg()
    {
        checkpointReachedUI.SetActive(false);
    }

}