using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketKiller : MonoBehaviour
{
    [Header("Bullet")]
    [SerializeField] private GameObject _rocketBullet;
    [SerializeField] private GameObject _lasserBullet;
  
    [Header("Firing properties")]
    [SerializeField] private float _fireRate=1.5f;
    private float _nextFire;
    [SerializeField] private float _maxRange=15f;
    private GameObject _player;
    
    [Header("Type of Projectile")]
    [SerializeField] private bool _isLaser=false;
 
    void Start ()
    {
        _player = GameObject.Find("Player");
        _nextFire = Time.time;
    }
    private void Update()
    {
        if (_player.gameObject != null)
        {
            
            Vector3 diff = _player.transform.position - transform.position;
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
        float distance = Vector3.Distance (_player.transform.position, transform.position);
        

        if (Time.time > _nextFire&&_player.gameObject!=null ) {
            if (_isLaser)
            {
                GameObject myBullet = MyObjectPool.Instance.GetLaserFromObjectPool();
                if (myBullet != null)
                {
                    myBullet.transform.position = transform.position;
                    myBullet.transform.rotation = transform.rotation;
                    myBullet.SetActive(true);
                }
            }
            else
            {
                GameObject myBullet = MyObjectPool.Instance.GetRocketFromObjectPool();
                if (myBullet != null)
                {
                    myBullet.transform.position = transform.position;
                    myBullet.transform.rotation = transform.rotation;
                    myBullet.SetActive(true);
                }
                
            }
            _nextFire = Time.time + _fireRate;
			     
        }
		
    }
}
