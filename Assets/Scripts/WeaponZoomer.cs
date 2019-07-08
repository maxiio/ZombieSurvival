using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoomer : MonoBehaviour
{

    [SerializeField] float zoomInFOV = 20;
    [SerializeField] float zoomOutFOV = 60;
    [SerializeField] float zoomOutSensitivity = 2;
    [SerializeField] float zoomInSensitivity = .5f;

    [SerializeField] Camera fpsCamera;
    [SerializeField] Weapon currentWeapon;

    [SerializeField] RigidbodyFirstPersonController fpsController;
    
    

    bool ZoomedInSwitch = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)) 
        {
            if (ZoomedInSwitch == false) 
            {
                ZoomedInSwitch = true;
                // currentWeapon.GetComponent<Renderer>().enabled = false;
                foreach (Transform child in currentWeapon.transform) {
                    child.GetComponent<Renderer>().enabled = false;
                }
                fpsCamera.fieldOfView = zoomInFOV;
                fpsController.mouseLook.XSensitivity = zoomInSensitivity;
                fpsController.mouseLook.YSensitivity = zoomInSensitivity;
            }
            else 
            {
                ZoomedInSwitch = false;
                
                // currentWeapon.GetComponent<Renderer>().enabled = true;
                foreach (Transform child in currentWeapon.transform) {
                    child.GetComponent<Renderer>().enabled = true;
                }

                fpsCamera.fieldOfView = zoomOutFOV;
                fpsController.mouseLook.XSensitivity = zoomOutSensitivity;
                fpsController.mouseLook.YSensitivity = zoomOutSensitivity;
            }
        }
    }
}
