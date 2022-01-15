using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LasserShooterKiller : MonoBehaviour
{
    private GameObject _player;
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private float _nextFire;
    [SerializeField] private float _fireRate=2f;
    void Start()
    {
        _player = GameObject.Find("Player");
        _nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // if (Time.time > _nextFire&&_player.gameObject!=null )
        // {
        //    
        //     _nextFire = Time.time + _fireRate;
        //
        // }
        StartCoroutine(_ShootCoroutine());
    }

    IEnumerator  _ShootCoroutine()
    {
     RaycastHit2D hit = Physics2D.Raycast(this.transform.position, _player.transform.position);
     if (hit)
     {
         var player = hit.transform.GetComponent<Player>();
         if (player != null)
         {
             Destroy(_player);
         }
         _lineRenderer.SetPosition(0,this.transform.position);
         _lineRenderer.SetPosition(1,_player.transform.position);
     }
     else
     {
         _lineRenderer.SetPosition(0,this.transform.position);
         _lineRenderer.SetPosition(1,_player.transform.position*10);
     }

     _lineRenderer.enabled = true;
     yield return new WaitForSeconds(0.02f);
     _lineRenderer.enabled = false;
    }
   
}
