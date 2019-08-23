using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ZombieCountUI : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI zombieCountText;
    [SerializeField] ZombieCounter zombieCounter;
    public Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled  = false;
        FindObjectOfType<Weapon>().enabled  = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        zombieCountText.text = zombieCounter.GetRemainingEnemies() + " / " + zombieCounter.GetTotalEnemies();
        quitButton.onClick.AddListener(QuitGame);
    }

    private void QuitGame()
    {
        Debug.Log("Quitting Game");
        Time.timeScale = 1;
        Application.Quit();
    }
}
