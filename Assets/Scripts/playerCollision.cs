using UnityEngine;
using UnityEngine.SceneManagement;

public class playerCollision : MonoBehaviour
{
    public characterController movement; // reference to our character controller script

    int nextScene;

    public float SpringForce = 2f;

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

            FindObjectOfType<gameManager>().LevelComplete();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Lethal")
        {
            movement.enabled = false;
            Debug.Log("You hit a lethal object");
            FindObjectOfType<gameManager>().EndGame();
        }

        if (collision.gameObject.tag == "Spring")
        {
            movement.rb2D.AddForce(transform.up * SpringForce, ForceMode2D.Impulse);
        }
    }
}
