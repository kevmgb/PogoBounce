using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class healthText : MonoBehaviour
{
    // Start is called before the first frame update

    //public GameObject player;
    public TextMeshProUGUI healthTextUI;

    void Start()
    {
        getPlayerHealth();
    }

    // Update is called once per frame
    void Update()
    {
        getPlayerHealth();
    }

    void getPlayerHealth()
    {
        GameObject player = GameObject.Find("pogo");

        int health = player.GetComponent<playerCollision>().health;
        
        healthTextUI.text = health.ToString();
    }
}
