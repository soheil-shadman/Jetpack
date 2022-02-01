using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalBomer : MonoBehaviour
{
    public GameObject Player;
    public GameObject bullet;
    
    public float fireRate;
    public float nextFire;
    void Start()
    {
        fireRate = 2f;
        nextFire = Time.time;
    }

    private void Update()
    {
        
        if (Player.gameObject != null)
        {
            Vector3 pos = transform.position;
            pos.y = Player.transform.position.y;
            transform.position = pos;
        
            CheckIfTimeToFire ();
        }

    }
    void CheckIfTimeToFire()
    {
        
        if (Time.time > nextFire&&Player.gameObject!=null ) {
            Instantiate (bullet, transform.position, transform.rotation*Quaternion.Euler(0, 0, 270));
            nextFire = Time.time + fireRate;
			
        }
		
    }
}
