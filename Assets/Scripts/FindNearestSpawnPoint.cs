using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindNearestSpawnPoint : MonoBehaviour
{
    public GameObject FindClosestSpawnPoint()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("SpawnPoint");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        Debug.Log("6");
        return closest;
    }
}
