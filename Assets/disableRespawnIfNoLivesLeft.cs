using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class disableRespawnIfNoLivesLeft : MonoBehaviour
{
    Button myButton;

    // Start is called before the first frame update
    void Start()
    {
        myButton = GetComponent<Button>();
    }

    void disableButton()
    {
        GameObject player = GameObject.Find("pogo");
        int pHealth = player.GetComponent<playerCollision>().health;

        Debug.LogWarning("disable " + pHealth);

        if (pHealth == 0)
        {
            myButton.interactable = false;
            Debug.LogWarning("pHealth is zero");
        }
        else
        {
            myButton.interactable = true;
        }

        Debug.Log("checkpoint has been clicked");
    }

    // Update is called once per frame
    void Update()
    {
        disableButton();
    }
}
