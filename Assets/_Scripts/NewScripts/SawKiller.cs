using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawKiller : MonoBehaviour
{
    void Update ()
    {
        
        transform.Rotate (65*Time.deltaTime,0,0); //rotates 50 degrees per second around z axis
    }
}
