using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    public CheckPoint checkPoint;

    //public float respawnDelay = .5f;

    public void RespawnPlayerFunc()
    {
        Debug.Log("Begin Respawn");
        Time.timeScale = 1f;
        //nearestSpawnPoint = pogoPlayer.GetComponent<FindNearestSpawnPoint>().FindClosestSpawnPoint();
        //Debug.Log(nearestSpawnPoint.GetComponent<Transform>().position);

        //pogoPlayer.MovePosition(nearestSpawnPoint.GetComponent<Transform>().position);
        //player.GetComponent<characterController>().enabled = true;
        //manager.gameHasEnded = false;
        //gameOverUI.SetActive(false);
        //Debug.Log("Player has respawned");

        checkPoint.RespawnPlayerToBoard();
    }

    //public void RespawnPlayerFunc()
    //{
    //    Invoke("RespawnPlayerFuncDelayed", respawnDelay);
    //    Debug.Log("Delay player respawn a little ...");
    //}
}
