using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{

    [SerializeField] Canvas gameOverCanvas;


    // Start is called before the first frame update
    void Start()
    {
        gameOverCanvas.enabled = false;
    }

    public  void HandleDeath()
    {
        Time.timeScale = 0;
        gameOverCanvas.enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
