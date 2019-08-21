using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDrop : MonoBehaviour
{
    public GameObject[] lootObjects;// objects which can be dropped as loot
    

    public int chance;

    public void DropLoot(Vector3 dropPosition)
    {
        //chance = Random.Range(1, 100); // Adds another chance to spawn an item
        if (chance > 70) // 50% chance
        {
            // create a random number
            int lootNumber = Random.Range(0, lootObjects.Length);
            // create a new gameobject on the position of the enemy
            GameObject loot = (GameObject)Instantiate(lootObjects[lootNumber], dropPosition + new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);

            // Instantiate(item, position + new Vector3(0.0f, someValue, 0.0f), Quaternion.identity);

            // Rigidbody lootRB = loot.GetComponent<Rigidbody>();
            // transform.eulerAngles = new Vector3(transform.eulerAngles.x, Random.Range(0, 360), transform.eulerAngles.z);
            // transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90, transform.eulerAngles.z);
            // float speed = 1;
            // lootRB.isKinematic = false;
            // Vector3 force = transform.up;
            // force = new Vector3(force.x, force.y, force.z);
            // lootRB.AddForce(force * speed);

            Debug.Log("Loot obj to spawn" + loot.name);
        }
        Debug.Log("Change to spawn" + chance);
    }
}
