using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelSelect : MonoBehaviour
{

    public Button[] lvlButtons;

    private void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);

        for (int i=0; i < lvlButtons.Length; i++)
        {
            if (i + 2 > levelAt)
                lvlButtons[i].interactable = false;
        }
    }
    public void loadLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void loadLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void loadLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void loadLevel4()
    {
        SceneManager.LoadScene("Level 4");
    }

    public void loadLevel5()
    {
        SceneManager.LoadScene("Level 5");
    }
}
