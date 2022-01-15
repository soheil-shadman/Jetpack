using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalRockerKiller : MonoBehaviour
{
  
  //  [SerializeField] private GameObject bullet;
    [SerializeField] private float _fireRate = 2f;
    [SerializeField] private float _horizentalPosition=25f;
    [SerializeField] private bool _isLaser;
    [SerializeField] private GameObject _lasserBullet;
    [SerializeField] private GameObject _rocketBullet;
    private GameObject _player;
    private float _nextFire;
    void Start()
    {
        _player = GameObject.Find("Player");
        _nextFire = Time.time;
    }

    private void Update()
    {
        
        if (_player.gameObject != null)
        {
            Vector3 pos = transform.position;
            pos.y = _player.transform.position.y;
            pos.x = _horizentalPosition;
            transform.position = pos;
        
            CheckIfTimeToFire ();
        }

    }
    void CheckIfTimeToFire()
    {
        
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
