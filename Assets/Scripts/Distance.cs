using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour
{
    public Transform player;

    public Transform exit;

    public float distance_to_exit;
    //public Text distanceText;

    public TextMeshProUGUI distanceText;

    // Update is called once per frame
    void Update()
    {
        distance_to_exit = Vector2.Distance(player.position, exit.position);
        distance_to_exit = Mathf.Round(distance_to_exit);
        distanceText.text = (" " + distance_to_exit.ToString() + " m");

    }
}
