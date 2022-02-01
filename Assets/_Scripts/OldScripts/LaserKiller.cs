using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserKiller : MonoBehaviour
{
    public ParticleSystem DeathParticle;

    void Start()
    {
        DeathParticle.Stop();
    }

    void OnTriggerEnter2D (Collider2D col)
    {
  
        if (col.gameObject.tag=="Player")
        {
            print("tringers");
            DeathParticle.transform.position = col.gameObject.transform.position;
            CMShake.Instance.Shacker(15f,0.2f);
            DeathParticle.Play();

            Destroy(col.gameObject);
         
        }
    }
}
