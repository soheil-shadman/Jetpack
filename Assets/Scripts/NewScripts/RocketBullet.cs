using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBullet : MonoBehaviour
{
   [SerializeField] private float _bulletSpeed = 15f;
   private Rigidbody2D _rigidbody2D;
   private GameObject _player;
   private Vector2 _moveDirection;
   private bool _doCommands;
   private bool _wasReset ;




   void Start()
   {


       _rigidbody2D = GetComponent<Rigidbody2D>();
       _player = GameObject.Find("Player");
       _doCommands = true;
       _wasReset = false;



   }

   void Update()
   {
       if (_player == null)
       {
           gameObject.SetActive(false);
       }
       if (_wasReset)
       {
           _wasReset = false;
           _doCommands = true;
       }

       if (_doCommands)
       {
           _moveDirection = (_player.transform.position - transform.position).normalized * _bulletSpeed;
           _rigidbody2D.velocity = new Vector3(_moveDirection.x, _moveDirection.y, 0);
           _doCommands = false;
           StartCoroutine(DeActiveObject());
                
       }
   }

   private IEnumerator DeActiveObject()
   {
       yield return new WaitForSeconds(3f);
       _wasReset = true;
       gameObject.SetActive(false);

   }

   void OnTriggerEnter2D (Collider2D col)
    {
  
        if (col.gameObject.tag=="Player")
        {
            GameState.Instance.ResetGameState();
            CinamaMachineController.Instance.Shacker(10f,0.15f);
            
            Destroy(col.gameObject);
         
        }
    }
}
