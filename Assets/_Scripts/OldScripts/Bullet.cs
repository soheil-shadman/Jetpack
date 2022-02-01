using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float moveSpeed = 11.5f;
    public bool isBlueDeath = false;

    Rigidbody2D rb;

    Player target;
    Vector2 moveDirection;
    public ParticleSystem DeathParticle;
    public ParticleSystem BlueDeathParticle;
   


    void Start () {
        
        DeathParticle.Stop();
        BlueDeathParticle.Stop();
        rb = GetComponent<Rigidbody2D> ();
        target = GameObject.FindObjectOfType<Player>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector3 (moveDirection.x, moveDirection.y,0);
        Destroy (gameObject, 3f);
    }

    void OnTriggerEnter2D (Collider2D col)
    {
  
        if (col.gameObject.tag=="Player")
        {
            print("tringers");
            CMShake.Instance.Shacker(15f,0.3f);
            if(isBlueDeath)
                BlueDeathParticle.Play();
            else
            {
                DeathParticle.Play();
            }
         
            Destroy(col.gameObject);
         
        }
    }
}