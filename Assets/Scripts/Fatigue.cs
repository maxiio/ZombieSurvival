using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Fatigue : MonoBehaviour
{
    // Start is called before the first frame update

    float fatigueLimit = 1.0f;
    float fatigueLevel;
    float fatigueDecreaseDecay = 0.5f;
    float fatigueIncreaseDecay = 0.1f;

    public Slider FatigueBar;

    public RigidbodyFirstPersonController firstPersonController;



    void Start()
    {
        fatigueLevel = fatigueLimit;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)) {
            DecreaseFatigue();
        }
        else if (fatigueLevel <= fatigueLimit)
        {
            IncreaseFatigue();
        }
        FatigueBar.value = fatigueLevel;
        if (fatigueLevel <= .15)
        {
            firstPersonController.SetFatigue(true);
        } else if (fatigueLevel >= .15)
        {
            firstPersonController.SetFatigue(false);
        }
    }

    public bool CanRun()
    {
        if (fatigueLevel >= 0.3)
        {
            return true;
        }
        return false;
    }
    private void DecreaseFatigue()
    {
        if (fatigueLevel >= 0) {
            fatigueLevel -= fatigueDecreaseDecay * Time.deltaTime;
        }
    }
    private void IncreaseFatigue()
    {
        if (fatigueLevel <= fatigueLimit) {
           fatigueLevel += fatigueIncreaseDecay * Time.deltaTime;
        }
    }
}
