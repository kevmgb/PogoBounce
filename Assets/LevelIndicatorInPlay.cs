using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelIndicatorInPlay : MonoBehaviour
{
    
    public TextMeshProUGUI levelNumber;
    int levelNum;

    // Start is called before the first frame update
    void Start()
    {
        displayLevelNameWhenPlaying();

    }

    void displayLevelNameWhenPlaying()
    {
        levelNum = SceneManager.GetActiveScene().buildIndex - 2;
        levelNumber.text = ("Level " + levelNum.ToString());
    }
}
