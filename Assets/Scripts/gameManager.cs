using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 2f;
   
    public GameObject completeLevelUI;

    public GameObject gameOverUI;

    public characterController player;

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
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
