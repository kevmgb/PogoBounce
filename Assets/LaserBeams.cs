using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeams : MonoBehaviour
{

    public float elapsedTime = 0;

    public float timeRemaining = 5;

    bool timesUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        deactivateLasers();

        if (timesUp == true)
        {
            //activateLasers();
            Debug.Log("Activate Lasers");
            Invoke("activateLasers", 5);
        }
    }

    void deactivateLasers()
    {
        if (elapsedTime >= timeRemaining)
        {
            Debug.Log("Time has run out!");
            this.gameObject.SetActive(false);
            elapsedTime = 0;
            timesUp = true;
        }
    }

    void activateLasers()
    {
        this.gameObject.SetActive(true);
        timesUp = false;
    }
}


