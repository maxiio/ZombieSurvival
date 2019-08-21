using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDrop : MonoBehaviour
{
    public GameObject[] lootObjects;// objects which can be dropped as loot
    public GameObject healthPickup, bulletPickup, shellsPickup, player;


    public int chance;

    public void DropLoot(GameObject enemy)
    {
        //chance = Random.Range(1, 100); // Adds another chance to spawn an item
        if (chance > 70) // 50% chance
        {
            // create a random number
            int lootNumber = Random.Range(0, lootObjects.Length);

            Vector3 dropPosition = enemy.transform.position;

            float playerHealth = player.GetComponent<PlayerHealth>().GetHealth();

            int bullets = player.GetComponent<Ammo>().GetAmmoCount(AmmoType.Bullets);
            int shells = player.GetComponent<Ammo>().GetAmmoCount(AmmoType.Shells);

            /*
            Loot Drop Logic
            Drop the key if it's the boss
            Drop the thing the player needs the most.
            If about to die, drop health, or whichever weapon is lower
             */

            if (enemy.name == "Boss")
            {
                Instantiate(lootObjects[lootNumber], dropPosition + new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);
            } else if (playerHealth < 20)
            {
                Instantiate(healthPickup, dropPosition + new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);
            }
            else if (shells <= 2 || bullets <= 4)
            {
                if (shells < bullets)
                {
                    Instantiate(shellsPickup, dropPosition + new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);
                } 
                else
                {
                    Instantiate(bulletPickup, dropPosition + new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);
                }
            }
            else 
            {
               Instantiate(lootObjects[lootNumber], dropPosition + new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);
            }
        }
    }
}
