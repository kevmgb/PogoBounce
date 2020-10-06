using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    GameObject player;

    Vector2 boardspawn;

    public gameManager manager;

    public GameObject gameOverUI;

    public bool firstCheckPointReached; // disable respawn button if no checkpoint was reached

    public bool reachedCheckpoint;

    public GameObject checkPointUI;

    public float checkPointUIDelay = 2f;

    private GameObject pogoplayer;

    public GameObject outOfLivesUI;

    //public GameObject myCanvas;


    #region Public Variables

    /// <summary>
    /// Indicate if the checkpoint is activated
    /// </summary>
    public bool Activated = false;

    #endregion

    #region Private Variables

    private Animator thisAnimator;

    #endregion

    #region Static Variables

    /// <summary>
    /// List with all checkpoints objects in the scene
    /// </summary>
    public static List<GameObject> CheckPointsList;

    #endregion

    #region Static Functions

    /// <summary>
    /// Get position of the last activated checkpoint
    /// </summary>
    /// <returns></returns>
    public static Vector2 GetActiveCheckPointPosition()
    {
        // If player die without activate any checkpoint, we will return a default position
        Vector2 result = new Vector2(0, 0);

        if (CheckPointsList != null)
        {
            foreach (GameObject cp in CheckPointsList)
            {
                // We search the activated checkpoint to get its position
                if (cp.GetComponent<CheckPoint>().Activated)
                {
                    result = cp.transform.position;
                    break;
                }
            }
        }
        Debug.Log(result);

        return result;
    }

    #endregion

    #region Private Functions

    /// <summary>
    /// Activate the checkpoint
    /// </summary>
    public  void ActivateCheckPoint()
    {
        // We deactive all checkpoints in the scene
        foreach (GameObject cp in CheckPointsList)
        {
            cp.GetComponent<CheckPoint>().Activated = false;
           
        }

        // We activated the current checkpoint
        Activated = true;
        
        if (reachedCheckpoint == false)
        {
            checkPointUI.SetActive(true);
            Debug.Log("SHOW CHECKPOINT REACHED UI");
            FindObjectOfType<AudioManager>().Play("checkpointSound");
            Debug.Log("PLAYED CHECKPOINT REACH SOUND");
            Invoke("checkPointUIDisable", checkPointUIDelay);
            reachedCheckpoint = true;
        }

        //TODO: Animate the checkpoint board with something like a tick
    }

    public void checkPointUIDisable()
    {
        checkPointUI.SetActive(false);
        Debug.Log("DISABLE CHECKPOINT REACHED UI");
    }

    #endregion

    void Start()
    {
        // We search all the checkpoints in the current scene
        CheckPointsList = GameObject.FindGameObjectsWithTag("CheckPoint").ToList();

        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        // If the player passes through the checkpoint, we activate it
        if (other.tag == "Player")
        {
            Debug.Log("Player touches checkpoint board");
            firstCheckPointReached = true;
            ActivateCheckPoint();
        }
    }

    public void RespawnPlayerToBoard()
    {
        Debug.Log("Begin Respawn");
        pogoplayer = GameObject.Find("pogo");
        int playerHealth = pogoplayer.GetComponent<playerCollision>().health;

        if (playerHealth != 0)
        {
            player = GameObject.FindGameObjectWithTag("Player");

            boardspawn = GetActiveCheckPointPosition();
            Debug.Log("board spawn: " + boardspawn);
            player.GetComponent<Rigidbody2D>().MovePosition(boardspawn);

            player.GetComponent<characterController>().enabled = true;
            manager.gameHasEnded = false;
            gameOverUI.SetActive(false);
            Debug.Log("Player has respawned");
        }
        else
        {
            Debug.Log("Display out of ads screen");

            //outOfLivesUI = Canvas.FindObject("OutOfLivesScreen");

            // the proble is find with tag only finds active objects in scene

           outOfLivesUI.SetActive(true);
            
            
            Debug.Log("Out of lives");
        }
        
    }

}