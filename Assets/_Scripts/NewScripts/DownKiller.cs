using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownKiller : MonoBehaviour
{
   
    [SerializeField] private float _startTimer=5f;
    [SerializeField] private float _goTopSpeed=1.5f;
    [SerializeField] private bool _isActive=true;
    private Rigidbody2D _rigidbody2D;
    private float _currentSpeed;
    private bool _goUp;

    
   
    void Start()
    {
        _rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(_Wait());
       
    }

    private void FixedUpdate()
    {
        if (_isActive)
        {
            if (_goUp)
            {
                var v = _rigidbody2D.velocity;
                v.y = _goTopSpeed;
                _rigidbody2D.velocity = v;
            }

        }
            
        

    }

    
    IEnumerator  _Wait()
    {
        _goUp = false;
        yield return new WaitForSeconds(_startTimer);
        _goUp = true;

    }
    void OnTriggerEnter2D (Collider2D col){
        if (col.tag == "Player") {
            CinamaMachineController.Instance.Shacker(10f,0.15f);
            GameState.Instance.ResetGameState();
            _goUp = false;
           Destroy(col.gameObject);
         
           
        }
    }
    
}
