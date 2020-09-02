using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour
{
    public Transform player;

    public Transform exit;

    float distance_to_exit;
    public Text distanceText;

    // Update is called once per frame
    void Update()
    {

        distance_to_exit = Vector2.Distance(player.position, exit.position);
        
        distance_to_exit = Mathf.Round(distance_to_exit);

        distanceText.text = ("Distance: " + distance_to_exit.ToString() + " m");

    }
}
