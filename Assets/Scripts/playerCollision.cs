using UnityEngine;

public class playerCollision : MonoBehaviour
{
    public characterController movement; // reference to our character controller script

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "finish")
        {
            movement.enabled = false;
            FindObjectOfType<gameManager>().LevelComplete();
        }

        if (other.gameObject.tag == "Lethal")
        {
            movement.enabled = false;
            FindObjectOfType<gameManager>().EndGame();
        }
    }
}
