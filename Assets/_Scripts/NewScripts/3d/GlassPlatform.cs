using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassPlatform : MonoBehaviour
{
    public GameObject colliderPlatform;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (colliderPlatform != null)
            {
                colliderPlatform.GetComponent<Collider>().enabled=false;
            }
        }
        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (colliderPlatform != null)
            {
                colliderPlatform.GetComponent<Collider>().enabled=true;
            }
        }
    }
}
