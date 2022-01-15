using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MyObjectPool : MonoBehaviour
{
    public static MyObjectPool Instance;
    
    [Header("Game Objects")] 
    public GameObject LaserBullet;
    public GameObject RocketBullet;
    public GameObject SimpleBullet;
    
    [Header("Amount of Objcets")] 
    public int amountOfLaserBullets=10;
    public int amountOfRocketBullets=30;
    public int amountOfSimpleBullets=80;
    
    //TempData
    private List<GameObject> _laserBulletListPool;
    private List<GameObject> _rocketBulletListPool;
    private List<GameObject> _simpleBulletListPool;



    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
           

    }
    // Start is called before the first frame update
    void Start()
    {
        
       
        GameObject tempLaser;
        GameObject tempRocket;
        GameObject tempSimple;
        
        var parent = GameObject.Find("ObjectPool"); 
        
        _laserBulletListPool = new List<GameObject>();
        _rocketBulletListPool = new List<GameObject>();
        _simpleBulletListPool = new List<GameObject>();
        
        for (int i = 0; i < amountOfLaserBullets; i++)
        {
            tempLaser = Instantiate(LaserBullet);
            tempLaser.gameObject.transform.parent = parent.transform;
            tempLaser.SetActive(false);
            _laserBulletListPool.Add(tempLaser);
        }
        for (int i = 0; i < amountOfRocketBullets; i++)
        {
            tempRocket = Instantiate(RocketBullet);
            tempRocket.gameObject.transform.parent = parent.transform;
            tempRocket.SetActive(false);
            _rocketBulletListPool.Add(tempRocket);
        }
        for (int i = 0; i < amountOfSimpleBullets; i++)
        {
            tempSimple = Instantiate(SimpleBullet);
            tempSimple.gameObject.transform.parent = parent.transform;
            tempSimple.SetActive(false);
            _simpleBulletListPool.Add(tempSimple);
        }
    }

    public GameObject GetLaserFromObjectPool()
    {
        for (int i = 0; i < amountOfLaserBullets; i++)
        {
            if (!_laserBulletListPool[i].activeInHierarchy)
            {
                return _laserBulletListPool[i];
            }

        }
        return null;
    }
    public GameObject GetRocketFromObjectPool()
    {
        for (int i = 0; i < amountOfRocketBullets; i++)
        {
            if (!_rocketBulletListPool[i].activeInHierarchy)
            {
                return _rocketBulletListPool[i];
            }

        }
        return null;
    }
    public GameObject GetSimpleFromObjectPool()
    {
        for (int i = 0; i < amountOfSimpleBullets; i++)
        {
            if (!_simpleBulletListPool[i].activeInHierarchy)
            {
                return _simpleBulletListPool[i];
            }

        }
        return null;
    }
   
}
