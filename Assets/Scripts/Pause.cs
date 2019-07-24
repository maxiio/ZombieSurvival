using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour 
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private AppStartup startupObject;
    private Difficulty difficulty;
    void Start()
    {
        // start game, see if difficulty is set
        if (startupObject) {
            Destroy(startupObject);
            PauseGame();

        } else {
            pausePanel.SetActive(false);
        }
    }
    void Update()
    {
        if(Input.GetKeyDown (KeyCode.Escape)) 
        {
            Debug.Log("I have pressed escape");
            if (!pausePanel.activeInHierarchy) 
            {
                PauseGame();
            } else if (pausePanel.activeInHierarchy) 
            {
                ContinueGame();   
            }
        } 
     }
    private void PauseGame()
    {
        Debug.Log("attempting to pause game.");
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled  = false;
        FindObjectOfType<Weapon>().enabled  = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //Disable scripts that still work while timescale is set to 0
    } 
    public void ContinueGame()
    {
        Debug.Log("attempting to continue game.");
        Time.timeScale = 1;
        FindObjectOfType<WeaponSwitcher>().enabled  = true;
        FindObjectOfType<Weapon>().enabled  = true;
        pausePanel.SetActive(false);
        //enable the scripts again
    }
}