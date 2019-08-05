using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCounter : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject[] zombies;
    int totalEnemies = 0;
    int remainingEnemies = 0;

    void Start()
    {
        zombies = GameObject.FindGameObjectsWithTag("Enemy");
        totalEnemies = zombies.Length;
        remainingEnemies = totalEnemies;
    }

    // Update is called once per frame
    public void DecrementEnemies()
    {
        remainingEnemies--;
        Debug.Log("Enemies Remaining: " + remainingEnemies);
    }
}
