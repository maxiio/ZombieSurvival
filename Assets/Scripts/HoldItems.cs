using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 public class HoldItems : MonoBehaviour {
 
 
     public float speed = 10;
     public bool canHold = true;
     public GameObject target;
     public Transform guide;
 
    void Update()
   {
       if (Input.GetKeyDown(KeyCode.E))
       {
           if (!canHold)
               throw_drop();
           else
               Pickup();
       }//mause If
  
       if (!canHold && target)
           target.transform.position = guide.position;
       
   }//update
 
     //We can use trigger or Collision
     void OnTriggerEnter(Collider col)
     {
         if (col.gameObject.GetComponent<Pickupable>())
             if (!target) // if we don't have anything holding
                 target = col.gameObject;
     }
 
     //We can use trigger or Collision
     void OnTriggerExit(Collider col)
     {
         if (col.GetComponent<Pickupable>())
         {
             if (canHold)
                 target = null;
         }
     }

     private void OnCollisionEnter(Collision col) {
         if (col.gameObject.GetComponent<Pickupable>()) {
             if (!target) // if we don't have anything holding
                 target = col.gameObject;
         }
     }
 
    bool CheckIfCloseToObject(float minimumDistance)
    {
        Pickupable[] pickupableObjects = GameObject.FindObjectsOfType<Pickupable>();//FindGameObjectsWithTag(tag);
    
        for (int i = 0; i < pickupableObjects.Length; ++i)
        {
            if (Vector3.Distance(transform.position, pickupableObjects[i].transform.position) <= minimumDistance)
                return true;
        }
    
        return false;
    }

     private void Pickup()
     {
         if (!target)
             return;

        if (CheckIfCloseToObject(2.5f) && target.GetComponent<Pickupable>())
        {
            //We set the object parent to our guide empty object.
            target.transform.SetParent(guide);
    
            //Set gravity to false while holding it
            target.GetComponent<Rigidbody>().useGravity = false;
    
            //we apply the same rotation our main object (Camera) has.
            target.transform.localRotation = transform.rotation;
            //We re-position the object on our guide object 
            target.transform.position = guide.position;
    
            canHold = false;
        }

     }
 
     private void throw_drop()
     {
         if (!target)
             return;
 
         //Set our Gravity to true again.
        target.GetComponent<Rigidbody>().useGravity = true;
          // we don't have anything to do with our ball field anymore
        target = null; 
         //Apply velocity on throwing
        guide.GetChild(0).gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;
 
        //Unparent our ball
        guide.GetChild(0).parent = null;
        canHold = true;
     }
 }
