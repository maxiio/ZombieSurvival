using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Instructions : MonoBehaviour
{

    public Button startButton;
    public GameObject loadingText;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        loadingText.SetActive(true);
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
