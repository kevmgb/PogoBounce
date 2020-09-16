using UnityEngine;
using UnityEngine.SceneManagement;

public class playerCollision : MonoBehaviour
{
    public characterController movement; // reference to our character controller script

    int nextScene;

    bool checkPoint_triggered;
    bool checkPoint_soundPlay;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "finish")
        {
            movement.enabled = false;
            
            // Unlock next scene //
            nextScene = SceneManager.GetActiveScene().buildIndex + 1;

            if (nextScene > PlayerPrefs.GetInt("LevelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextScene);
            }
            // End // 
            FindObjectOfType<AudioManager>().Play("playerWin");
            FindObjectOfType<gameManager>().LevelComplete();
            Debug.Log("Showed level complete ui");
        }

        if (other.gameObject.tag == "SpawnPoint")
        {
            if (checkPoint_triggered == false)
            {
                checkPoint_triggered = true;
                FindObjectOfType<gameManager>().CheckPointReached();
                Debug.Log("Showed checkpoint activated ui");
            }
            else
            {
                // checkPoint_triggered = false;
                Debug.Log("Checkpoint already triggered.");
            }

            if (checkPoint_soundPlay == false)
            {
                checkPoint_soundPlay = true;
                FindObjectOfType<AudioManager>().Play("checkpointSound");
            }
            else
            {
                // checkPoint_soundPlay = false;
                Debug.Log("Checkpoint sound already played");
            }
           
            
            
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Lethal")
        {
            movement.enabled = false;
            //FindObjectOfType<AudioManager>().Play("playerLose");
            Debug.Log("You hit a lethal object");
            FindObjectOfType<gameManager>().EndGame();
            Debug.Log("Showed game over ui");
        }
    }

}
