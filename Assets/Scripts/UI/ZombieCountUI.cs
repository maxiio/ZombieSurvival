using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ZombieCountUI : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI zombieCountText;
    [SerializeField] ZombieCounter zombieCounter;
    [SerializeField] TextMeshProUGUI summaryText;
    [SerializeField] TextMeshProUGUI timeText;

    public Button quitButton, replayButton;

    // Start is called before the first frame update
    void Start()
    {
        System.TimeSpan timeElapsed = System.TimeSpan.FromSeconds(Time.time);
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled  = false;
        FindObjectOfType<Weapon>().enabled  = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        string tmp = summaryText.text;
        int remainingEnemies = zombieCounter.GetRemainingEnemies();
        int totalEnemies = zombieCounter.GetTotalEnemies();
        zombieCountText.text = remainingEnemies + "/" + totalEnemies;
        if (totalEnemies - remainingEnemies == 0)
        {
            summaryText.text = tmp + "You eliminated the zombie threat! All hail the Hero of the Lab!";
        } else if (totalEnemies - remainingEnemies > 4)
        {
            summaryText.text = tmp + "You got most of the zombies, We can take care of the rest.";
        } else
        {
            summaryText.text = tmp + "You survived, but the town was overwhelmed by the zombies you missed.";
        }
        string fmt = @"mm\:ss";

        string str = timeElapsed.ToString(fmt);
        timeText.SetText(str);
        
        quitButton.onClick.AddListener(QuitGame);
        replayButton.onClick.AddListener(ReplayGame);
    }

    private void QuitGame()
    {
        Debug.Log("Quitting Game");
        Time.timeScale = 1;
        Application.Quit();
    }

    private void ReplayGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
}
