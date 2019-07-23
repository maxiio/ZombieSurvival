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
    //Make sure to attach these Buttons in the Inspector
    public Button m_YourFirstButton, m_YourSecondButton, m_YourThirdButton, saveButton;

<<<<<<< HEAD:Assets/Scripts/Difficulty.cs
=======
    enum DifficultyLevel
    {
        Easy = 0,
        Medium = 1,
        Hard = 2
    }

    DifficultyLevel difficulty;
>>>>>>> ae3e238c8dc704d4889741d0003ad493202f101a:Assets/Difficulty.cs

    void Start()
    {
        m_YourThirdButton.onClick.AddListener(() => SetDifficulty(DifficultyLevel.Hard));
        m_YourSecondButton.onClick.AddListener(() => SetDifficulty(DifficultyLevel.Medium));
        m_YourFirstButton.onClick.AddListener(() => SetDifficulty(DifficultyLevel.Easy));
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
<<<<<<< HEAD:Assets/Scripts/Difficulty.cs
        EnemyHealth[] enemies = FindObjectsOfType<EnemyHealth>();
        foreach (EnemyHealth enemy in enemies)
        {
            enemy.SetDifficulty(level);
        }
=======
        int l = (int)level;
        PlayerPrefs.SetInt("difficulty", l);
        Debug.Log((DifficultyLevel)PlayerPrefs.GetInt("difficulty", 1));
>>>>>>> ae3e238c8dc704d4889741d0003ad493202f101a:Assets/Difficulty.cs
    }


}