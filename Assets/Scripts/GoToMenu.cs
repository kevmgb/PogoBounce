﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadMenu", 1.5f);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
