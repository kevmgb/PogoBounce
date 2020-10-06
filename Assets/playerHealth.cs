using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    // Start is called before the first frame update

    public playerCollision player;

    public TextMeshProUGUI healthText;
    void Start()
    {
        healthText.text = player.health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
