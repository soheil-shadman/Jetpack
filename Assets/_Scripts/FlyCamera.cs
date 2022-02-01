using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCamera : MonoBehaviour
{
    [SerializeField] private float speed;
    

    void Update () {
        transform.Translate(0,speed*Time.deltaTime*Input.GetAxisRaw("Vertical"),0);
    }
     

}