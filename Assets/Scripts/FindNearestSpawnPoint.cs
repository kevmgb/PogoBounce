using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindNearestSpawnPoint : MonoBehaviour
{
    public GameObject FindClosestSpawnPoint()
    {
        GameObject[] gos;
        Debug.Log("1");
        gos = GameObject.FindGameObjectsWithTag("SpawnPoint");
        Debug.Log("2");
        GameObject closest = null;
        Debug.Log("3");
        float distance = Mathf.Infinity;
        Debug.Log("4");
        Vector3 position = transform.position;
        Debug.Log("5");
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
