using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UIElements;

public class SpiralKiller : MonoBehaviour
{
    [SerializeField] private float _fireRate = 2f;
    private float _nextFire;
   

    [SerializeField] private GameObject _simpleBullet;
    private float angle = 0f;
    private float _maxDistance = 15f;
    private GameObject _player;
    private Vector2 _bulletMoveDirection;
    void Start()
    {
        _player = GameObject.Find("Player");
        _nextFire = Time.time;
    }

    private void Update()
    {
        
        if (_player.gameObject != null)
        {
            float distance = Vector3.Distance (_player.transform.position, transform.position);
        

            if (Time.time > _nextFire&&distance<_maxDistance&&_player.gameObject!=null ) {
                Fire();
                _nextFire = Time.time + _fireRate;
			     
            }
          
        }

    }
    void Fire()
    {

        for (var i = 0; i <= 1; i++)
        {
            float bulDrX = transform.position.x + Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180f);
            float bulDrY = transform.position.y + Mathf.Cos(((angle + 180f * i) * Mathf.PI) / 180f);
            Vector3 bulMoveVector = new Vector3(bulDrX, bulDrY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;
            GameObject myBullet = MyObjectPool.Instance.GetSimpleFromObjectPool();
            
            if (myBullet != null)
            {
                myBullet.transform.position = transform.position;
                myBullet.transform.rotation = transform.rotation;
                myBullet.SetActive(true);
                myBullet.GetComponent<SimpleBullet>().MoveTo(bulDir);
                
            }
         
          
           
        }
        angle += 10f;
        if (angle >= 360f)
        {
            angle = 0f;
        }
		
    }
}
