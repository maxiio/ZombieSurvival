using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public Button easyButton, mediumButton, hardButton, saveButton, miniMapButton, healthBarButton, ammoButton, quitButton;
    public TMP_Text healthButtonText, ammoButtonText, miniMapButtonText;

    [SerializeField] Pause pauseMenu;

    [SerializeField] GameObject healthBar;
    [SerializeField] GameObject fatigueBar;
    [SerializeField] GameObject minimap;
    [SerializeField] GameObject ammo;

    public bool miniMapEnabled;
    public bool healthBarEnabled;
    public bool ammoEnabled;


    bool gameJustStarted = true;

    DifficultyLevel difficulty;

    void Start()
    {
        miniMapEnabled = minimap.activeSelf;
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
        if (ammoEnabled)
        {
            ammoButtonText.SetText("HIDE AMMO");
        }
        else
        {
            ammoButtonText.SetText("SHOW MAP");
        }
        ammo.SetActive(ammoEnabled);
    }


    private void ToggleHealthBar()
    {
        healthBarEnabled = !healthBarEnabled;
        if (healthBarEnabled)
        {
            healthButtonText.SetText("HIDE HEALTH");
        }
        else
        {
            healthButtonText.SetText("SHOW HEALTH");
        }
        healthBar.SetActive(healthBarEnabled);
        fatigueBar.SetActive(healthBarEnabled);   
    }
    public void ToggleMinimap()
    {
        miniMapEnabled = !miniMapEnabled;
        if (miniMapEnabled)
        {
            miniMapButtonText.SetText("HIDE MAP");
        }
        else
        {
            miniMapButtonText.SetText("SHOW MAP");
        }
        minimap.SetActive(miniMapEnabled);
    }
    public DifficultyLevel GetDifficulty()
    {
        difficulty = (DifficultyLevel)PlayerPrefs.GetInt("difficulty", 1);
        return difficulty;
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

    private void QuitGame()
    {
        Time.timeScale = 1;
        Application.Quit();
    }
}