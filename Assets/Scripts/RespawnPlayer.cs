using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    
    public Rigidbody2D pogoPlayer;
    public GameObject player;
    public GameObject gameOverUI;
    public int spawnDelay = 2;
    public GameObject nearestSpawnPoint;
    public gameManager manager;

    public void RespawnPlayerFunc ()
    {
        Debug.Log("Begin Respawn");
        nearestSpawnPoint = pogoPlayer.GetComponent<FindNearestSpawnPoint>().FindClosestSpawnPoint();
        Debug.Log(nearestSpawnPoint.GetComponent<Transform>().position);

        pogoPlayer.MovePosition(nearestSpawnPoint.GetComponent<Transform>().position);
        player.GetComponent<characterController>().enabled = true;
        manager.gameHasEnded = false;
        gameOverUI.SetActive(false);
        Debug.Log("Player has respawned");
    }
    
}
