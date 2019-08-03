// To use this example, attach this script to an empty GameObject.
// Create three buttons (Create>UI>Button). Next, select your
// empty GameObject in the Hierarchy and click and drag each of your
// Buttons from the Hierarchy to the Your First Button, Your Second Button
// and Your Third Button fields in the Inspector.
// Click each Button in Play Mode to output their message to the console.
// Note that click means press down and then release.

using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Button easyButton, mediumButton, hardButton, saveButton, miniMapButton, compassButton;
    [SerializeField] Pause pauseMenu;
    [SerializeField] GameObject minimap;
    [SerializeField] GameObject compass;

    public bool minimapEnabled;
    public bool compassEnabled;


    bool gameJustStarted = true;

    DifficultyLevel difficulty;

    void Start()
    {
        minimapEnabled = minimap.activeSelf;
        compassEnabled = compass.activeSelf;
        hardButton.onClick.AddListener(() => SetDifficulty(DifficultyLevel.Hard, hardButton));
        mediumButton.onClick.AddListener(() => SetDifficulty(DifficultyLevel.Medium, mediumButton));
        easyButton.onClick.AddListener(() => SetDifficulty(DifficultyLevel.Easy, easyButton));
        saveButton.onClick.AddListener(ClickSave);
        miniMapButton.onClick.AddListener(ToggleMinimap);
        compassButton.onClick.AddListener(ToggleCompass);
        GetDifficulty();
    }

    public DifficultyLevel GetDifficulty()
    {
        difficulty = (DifficultyLevel)PlayerPrefs.GetInt("difficulty", 1);
        return difficulty;
    }

    public void ToggleMinimap()
    {
        minimapEnabled = !minimapEnabled;
        minimap.SetActive(minimapEnabled);
        if (minimapEnabled)
        {
            miniMapButton.GetComponentInChildren<Text>().text = "MAP OFF";
        } 
        else
        {
            miniMapButton.GetComponentInChildren<Text>().text = "MAP ON";
        }
    }

    public void ToggleCompass()
    {
        compassEnabled = !compassEnabled;
        compass.SetActive(compassEnabled);
        if (compassEnabled)
        {
            compassButton.GetComponentInChildren<Text>().text = "COMPASS OFF";
        } 
        else
        {
            compassButton.GetComponentInChildren<Text>().text = "COMPASS ON";
        }
    }
    void ClickSave()
    {
        PlayerPrefs.Save();
        if (gameJustStarted) //else manually hit escape  again to return to game, this is confising on launch
        {   
            gameJustStarted = false;
            pauseMenu.ContinueGame();
        }
    }

    void SetDifficulty(DifficultyLevel level, Button button) 
    {
        EnemyHealth[] enemies = FindObjectsOfType<EnemyHealth>();
        foreach (EnemyHealth enemy in enemies)
        {
            enemy.SetDifficulty(level);
        }

        int l = (int)level;
        PlayerPrefs.SetInt("difficulty", l);
        Debug.Log((DifficultyLevel)PlayerPrefs.GetInt("difficulty"));
    }

}