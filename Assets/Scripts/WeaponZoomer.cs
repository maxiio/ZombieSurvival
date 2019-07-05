using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoomer : MonoBehaviour
{

    [SerializeField] float zoomIn = 20;
    [SerializeField] float zoomOut = 60;

    [SerializeField] Camera fpsCamera;


    bool ZoomedInSwitch = false;

    void SetWeaponZoom(float zoom) {
        fpsCamera.fieldOfView = zoom;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)) 
        {
            if (ZoomedInSwitch == false) 
            {
                ZoomedInSwitch = true;
                SetWeaponZoom(zoomIn);
            }
            else 
            {
                ZoomedInSwitch = false;
                SetWeaponZoom(zoomOut);
            }
        }
    }
}
