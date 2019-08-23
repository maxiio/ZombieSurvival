using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZombieCountUI : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI zombieCountText;
    [SerializeField] ZombieCounter zombieCounter;

    // Start is called before the first frame update
    void Start()
    {
        zombieCountText.text = zombieCounter.GetRemainingEnemies() + " / " + zombieCounter.GetTotalEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
