using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 15f;
    [SerializeField]    private Rigidbody2D _rigidbody2D;
    private GameObject _player;
    private bool _doCommands;
    private bool _wasReset ;
    void Start () {
        
        _player = GameObject.Find("Player");
        _doCommands = true;
        _wasReset = false;

        // _moveDirection = (_player.transform.position - transform.position).normalized * _bulletSpeed;


    }

    void Update()
    {
        if (_wasReset)
        {
            _wasReset = false;
            _doCommands = true;
        }
        
        if (_player == null)
        {
                gameObject.SetActive(false);
        }

        if (_doCommands)
        {
            _doCommands = false;
            StartCoroutine(DeActiveObject());
                
        }
        
        
    }
    private IEnumerator DeActiveObject()
    {
        yield return new WaitForSeconds(2);
        _wasReset = true;
        gameObject.SetActive(false);
        
    }
    public void MoveTo(Vector2 moveDirection)
    {
        _rigidbody2D.velocity = moveDirection*_bulletSpeed;
    }

    void OnTriggerEnter2D (Collider2D col)
    {
  
        if (col.gameObject.tag=="Player")
        {
           
            CinamaMachineController.Instance.Shacker(10f,0.15f);
            
            GameState.Instance.ResetGameState();
            Destroy(col.gameObject);
         
        }
    }
}
