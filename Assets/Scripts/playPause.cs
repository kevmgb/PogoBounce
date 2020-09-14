using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class playPause : MonoBehaviour
{

    public Image image;
    public bool isPress = false;
    public Button button;
    public Sprite Fsprite;
    public Sprite Ssprite;
    // Use this for initialization
    void Start()
    {
        image = button.GetComponent<Image>();
    }

    // Update is called once per frame



    public void ChangeSprites()
    {
        isPress = !isPress;
        if (isPress == true)
        {
            image.sprite = Ssprite;

        }
        else
        {
            image.sprite = Fsprite;

        }
    }
}