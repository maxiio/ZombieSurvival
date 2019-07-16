using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 public class HoldItems : MonoBehaviour {
 
 
     public float speed = 10;
     public bool canHold = true;
     public GameObject ball;
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
  
       if (!canHold && ball)
           ball.transform.position = guide.position;
       
   }//update
 
     //We can use trigger or Collision
     void OnTriggerEnter(Collider col)
     {
         Debug.Log("Trigger Entered");
         if (col.gameObject.tag == "ball")
         Debug.Log("I hit a thing, it is a ball");
             if (!ball) // if we don't have anything holding
                 ball = col.gameObject;
     }
 
     //We can use trigger or Collision
     void OnTriggerExit(Collider col)
     {
         if (col.gameObject.tag == "ball")
         {
             if (canHold)
                 ball = null;
         }
     }

     private void OnCollisionEnter(Collision col) {
          Debug.Log("Trigger Entered");
         if (col.gameObject.tag == "ball") {
         Debug.Log("I hit a thing, it is a ball");
             if (!ball) // if we don't have anything holding
                 ball = col.gameObject;
         }
     }
 
    bool CheckCloseToTag(string tag, float minimumDistance)
    {
        GameObject[] goWithTag = GameObject.FindGameObjectsWithTag(tag);
    
        for (int i = 0; i < goWithTag.Length; ++i)
        {
            if (Vector3.Distance(transform.position, goWithTag[i].transform.position) <= minimumDistance)
                return true;
        }
    
        return false;
    }

     private void Pickup()
     {
         if (!ball)
             return;
        Debug.Log("thing trying to pickup is: " + ball.name);

        if (CheckCloseToTag("ball", 2.0f) && ball.tag == "ball")

        {
                     //We set the object parent to our guide empty object.
         ball.transform.SetParent(guide);
 
         //Set gravity to false while holding it
         ball.GetComponent<Rigidbody>().useGravity = false;
 
         //we apply the same rotation our main object (Camera) has.
         ball.transform.localRotation = transform.rotation;
         //We re-position the ball on our guide object 
         ball.transform.position = guide.position;
 
         canHold = false;
        }

     }
 
     private void throw_drop()
     {
         if (!ball)
             return;
 
         //Set our Gravity to true again.
         ball.GetComponent<Rigidbody>().useGravity = true;
          // we don't have anything to do with our ball field anymore
          ball = null; 
         //Apply velocity on throwing
         guide.GetChild(0).gameObject.GetComponent<Rigidbody>().velocity = transform.forward * speed;
 
         //Unparent our ball
         guide.GetChild(0).parent = null;
         canHold = true;
     }
 }
