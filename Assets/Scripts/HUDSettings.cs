using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDSettings : MonoBehaviour
{

    [SerializeField] GameObject minimap;

    public bool minimapEnabled;

    public void ToggleMinimap(bool enabled)
    {
        enabled = (enabled == true) ? false : true;
    }
}
