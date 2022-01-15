using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour
{ 
    
    public GameObject Player;
    public GameObject bullet;
    
   public float fireRate;
   public float nextFire;
 
    void Start () {
        fireRate = 1.5f;
        nextFire = Time.time;
    }
    private void Update()
    {
        if (Player.gameObject != null)
        {
            
            Vector3 diff = Player.transform.position - transform.position;
            diff.Normalize();
 
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            if(diff.x>=0)
                transform.rotation = Quaternion.Euler(0f, 0, rot_z );
            else
            {
                transform.rotation = Quaternion.Euler(0f, 180, -rot_z+180 );
            }
        
            CheckIfTimeToFire ();
        }

    }
    void CheckIfTimeToFire()
    {
        float distance = Vector3.Distance (Player.transform.position, transform.position);
        

        if (Time.time > nextFire&&distance<15f&&Player.gameObject!=null ) {
            Instantiate (bullet, transform.position, transform.rotation*Quaternion.Euler(0, 0, 270));
            nextFire = Time.time + fireRate;
			
        }
		
    }
 
 
  
  
}
