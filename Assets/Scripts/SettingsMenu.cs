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
    public Button easyButton, mediumButton, hardButton, saveButton, miniMapButton, compassButton, healthBbarButton, ammoButton;
    [SerializeField] Pause pauseMenu;

    [SerializeField] GameObject healthBar;
    [SerializeField] GameObject minimap;
    [SerializeField] GameObject compass;
    [SerializeField] GameObject ammo;

    public bool minimapEnabled;
    public bool healthBarEnabled;
    public bool compassEnabled;
    public bool ammoEnabled;


    bool gameJustStarted = true;

    DifficultyLevel difficulty;

    void Start()
    {
        minimapEnabled = minimap.activeSelf;
        ammoEnabled = ammo.activeSelf;
        compassEnabled = compass.activeSelf;
        healthBarEnabled = healthBar.activeSelf;
        hardButton.onClick.AddListener(() => SetDifficulty(DifficultyLevel.Hard, hardButton));
        mediumButton.onClick.AddListener(() => SetDifficulty(DifficultyLevel.Medium, mediumButton));
        easyButton.onClick.AddListener(() => SetDifficulty(DifficultyLevel.Easy, easyButton));
        saveButton.onClick.AddListener(ClickSave);
        miniMapButton.onClick.AddListener(ToggleMinimap);
        compassButton.onClick.AddListener(ToggleCompass);
        healthBbarButton.onClick.AddListener(ToggleHealthBar);
        ammoButton.onClick.AddListener(ToggleAmmo);
        GetDifficulty();
    }
    private void ToggleAmmo()
    {
        ammoEnabled = !ammoEnabled;
        ammo.SetActive(ammoEnabled);
        if (ammoEnabled)
        {
            ammoButton.GetComponentInChildren<Text>().text = "AMMMO OFF";
        } 
        else
        {
            ammoButton.GetComponentInChildren<Text>().text = "AMMO ON";
        }    
        
    }
    private void ToggleHealthBar()
    {
        healthBarEnabled = !healthBarEnabled;
        healthBar.SetActive(healthBarEnabled);
        if (healthBarEnabled)
        {
            healthBbarButton.GetComponentInChildren<Text>().text = "HEALTH BAR OFF";
        } 
        else
        {
            healthBbarButton.GetComponentInChildren<Text>().text = "HEALTH BAR ON";
        }    
        
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