using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelLoad : MonoBehaviour
{
    //public GameObject textObject;

    public TextMeshProUGUI levelNumber;
    void Start()
    {
        Button btn = this.gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        //Text levelText = textObject.GetComponent<Text>();
        Debug.Log("You have clicked the button!");
        LoadLevel(levelNumber.text);
        Debug.Log(levelNumber.text);
    }

    public void LoadLevel(string levelNum)
    {
        SceneManager.LoadScene("Level " + levelNum);
    }
}
