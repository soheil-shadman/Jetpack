using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleKiller : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private GameObject _movmentRight;
    [SerializeField] private GameObject _movmentLeft;
    private Vector3 _vector3 = Vector3.right;
    private bool _stop;
    
    [SerializeField] private float _speed = 5f;
    
    void Start()
    {
        _stop = false;
        _rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
        
        

    }

  
    void Update()
    {
        if (!_stop)
        {
            transform.Translate(_vector3*_speed*Time.deltaTime);
    
            if(transform.position.x >= _movmentRight.transform.position.x){
                _vector3 = Vector3.left;
            }else if(transform.position.x <=_movmentLeft.transform.position.x){
                _vector3 = Vector3.right;
            }
        }
     

    }
    void OnCollisionEnter2D (Collision2D col){
        if (col.gameObject.tag == "Player")
        {
            _stop = true;
            CinamaMachineController.Instance.Shacker(10f,0.15f);
            GameState.Instance.ResetGameState();
            Destroy(col.gameObject);
        }
    }
  
}