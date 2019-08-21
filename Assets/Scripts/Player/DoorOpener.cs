using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
//      var yourAnimation : Animation; // choose the animation which will start when triggered
//  var FallerObject : GameObject; //Implement your Faller game object into this variable in the inspector

    private Animator anim;
    bool playedAnimation = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
  
            Animator anim  = GetComponent<Animator>();
            if (null != anim)
            {
                // play Bounce but start at a quarter of the way though
                if (other.GetComponent<KeyRing>().HasKey() && playedAnimation == false)
                {
                    anim.Play("DoorAnimation", 0, 0);
                    playedAnimation = true;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
