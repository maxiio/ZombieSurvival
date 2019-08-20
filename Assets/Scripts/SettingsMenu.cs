using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public Button easyButton, mediumButton, hardButton, saveButton, miniMapButton, healthBarButton, ammoButton, quitButton;
    [SerializeField] Pause pauseMenu;

    [SerializeField] GameObject healthBar;
    [SerializeField] GameObject fatigueBar;
    [SerializeField] GameObject minimap;
    [SerializeField] GameObject ammo;

    public bool minimapEnabled;
    public bool healthBarEnabled;
    public bool ammoEnabled;


    bool gameJustStarted = true;

    DifficultyLevel difficulty;

    void Start()
    {
        minimapEnabled = minimap.activeSelf;
        ammoEnabled = ammo.activeSelf;
        healthBarEnabled = healthBar.activeSelf;
        hardButton.onClick.AddListener(() => SetDifficulty(DifficultyLevel.Hard, hardButton));
        mediumButton.onClick.AddListener(() => SetDifficulty(DifficultyLevel.Medium, mediumButton));
        easyButton.onClick.AddListener(() => SetDifficulty(DifficultyLevel.Easy, easyButton));
        saveButton.onClick.AddListener(ClickSave);
        miniMapButton.onClick.AddListener(ToggleMinimap);
        healthBarButton.onClick.AddListener(ToggleHealthBar);
        ammoButton.onClick.AddListener(ToggleAmmo);
        quitButton.onClick.AddListener(QuitGame);
        GetDifficulty();
    }
    private void ToggleAmmo()
    {
        ammoEnabled = !ammoEnabled;
        ammo.SetActive(ammoEnabled);
    }
     private void QuitGame()
    {
        Time.timeScale = 1;
        Application.Quit();
    }

    private void ToggleHealthBar()
    {
        healthBarEnabled = !healthBarEnabled;
        healthBar.SetActive(healthBarEnabled);
        fatigueBar.SetActive(healthBarEnabled);   
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
    }

    void ClickSave()
    {
        PlayerPrefs.Save();
        if (gameJustStarted) //else manually hit escape  again to return to game, this is confising on launch
        {   
            gameJustStarted = false;
        }
        pauseMenu.ContinueGame();

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