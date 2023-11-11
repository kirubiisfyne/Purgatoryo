 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class GraveOnClick_sc : MonoBehaviour
{
    public Coffin_sc coffinSc;
    public AudioSource scream;

    private bool enableScream;

    private void Update()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Triggered!");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            coffinSc.setBoolChase();
            scream.enabled = true;
        }
    }
}
