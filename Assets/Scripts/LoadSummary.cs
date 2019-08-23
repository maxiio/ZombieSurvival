using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoadSummary : MonoBehaviour
{
    
    [SerializeField] GameObject summaryCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            summaryCanvas.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
