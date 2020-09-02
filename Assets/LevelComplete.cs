using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    int nextScene;
    public void LoadNextLevel()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextScene);

        if(nextScene > PlayerPrefs.GetInt("LevelAt"))
        {
            PlayerPrefs.SetInt("levelAt", nextScene);
        }

    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
