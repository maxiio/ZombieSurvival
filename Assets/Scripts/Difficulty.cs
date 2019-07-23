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

public class Difficulty : MonoBehaviour
{
    public Button easyButton, mediumButton, hardButton, saveButton;

    DifficultyLevel difficulty;

    void Start()
    {
        hardButton.onClick.AddListener(() => SetDifficulty(DifficultyLevel.Hard));
        mediumButton.onClick.AddListener(() => SetDifficulty(DifficultyLevel.Medium));
        easyButton.onClick.AddListener(() => SetDifficulty(DifficultyLevel.Easy));
        saveButton.onClick.AddListener(ClickSave);
        GetDifficulty();
        Debug.Log(difficulty);
    }

    private void GetDifficulty()
    {
        difficulty = (DifficultyLevel)PlayerPrefs.GetInt("difficulty", 1);
    }

    void ClickSave()
    {
        PlayerPrefs.Save();
    }

    void SetDifficulty(DifficultyLevel level) 
    {
        Debug.Log(level);
        EnemyHealth[] enemies = FindObjectsOfType<EnemyHealth>();
        foreach (EnemyHealth enemy in enemies)
        {
            enemy.SetDifficulty(level);
        }

        int l = (int)level;
        PlayerPrefs.SetInt("difficulty", l);
        Debug.Log((DifficultyLevel)PlayerPrefs.GetInt("difficulty", 1));
    }


}