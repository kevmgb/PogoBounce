using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelIndicator : MonoBehaviour
{
    public int levelNum;
    public TextMeshProUGUI levelName;

    // Start is called before the first frame update
    void Start()
    {
        displayLevelName();
    }

    void displayLevelName()
    {
        levelNum = SceneManager.GetActiveScene().buildIndex - 2;
        levelName.text = ("level " + levelNum.ToString());
    }
}
