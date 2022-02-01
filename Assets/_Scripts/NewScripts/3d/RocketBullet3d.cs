using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBullet3d : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 15f;
    private Rigidbody _rigidbody;
    private GameObject _player;
    private Vector3 _moveDirection;
    private bool _doCommands;
    private bool _wasReset ;




    void Start()
    {


        _rigidbody = GetComponent<Rigidbody>();
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
            _rigidbody.velocity = new Vector3(_moveDirection.x, _moveDirection.y, _moveDirection.z);
            _doCommands = false;
            StartCoroutine(DeActiveObject());
                
        }
    }

    private IEnumerator DeActiveObject()
    {
        yield return new WaitForSeconds(6f);
        _wasReset = true;
        gameObject.SetActive(false);

    }

    void OnTriggerEnter (Collider col)
    {
  
        if (col.gameObject.tag=="Player")
        {
            GameState.Instance.ResetGameState();
           // CinamaMachineController.Instance.Shacker(10f,0.15f);
            
            Destroy(col.gameObject);
         
        }
    }
}
