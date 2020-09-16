using UnityEngine;
using UnityEngine.SceneManagement;

public class playerCollision : MonoBehaviour
{
    public characterController movement; // reference to our character controller script

    int nextScene;

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
