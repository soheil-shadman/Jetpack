using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    [Header("Semi Publics")]
    [SerializeField] private float _maxFuelLimit = 120f;
    [SerializeField] private float groundCheckRadius = 0.3f;
    [SerializeField] private float _backgroundHorizentalOffset = 1.5f;
    
    //Ground nd top
    [Header("Am i Hitting?")]
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private Transform headCheck;
    [SerializeField] private Transform groundCheck;


    [Header("Rates")]
    [SerializeField] private float _reFuelRate = 30f;
    [SerializeField] private float _burnFuelRate = 30f;
    
    
    [Header("Force")]
    [SerializeField] private float _startSpeed = 15f;
    [SerializeField] private float _horizentalSpeed = 10f;
    [SerializeField] private float _acceleration=10f;
    [SerializeField] private float _maxSpeed=20f;

    [Header("Background")] [SerializeField]
    private GameObject _background;
    
    // Probebly input
    
    // Components
    private Rigidbody2D _rigidbody2D;
    
    // Temp Bools
    private bool _isGrounded;
    private bool _resetSpeed=false;
    private bool _switchSideRight = false;
    private bool _switchSideLeft = true;
    private bool _outOfFuel = false;
    private float _currentSpeed;
    private float _backGroundwidth;
  

    //Temp Data
    private float _currentFuel;
    
    
    void Start()
    {
        _currentFuel = _maxFuelLimit;
        _backGroundwidth = _background.GetComponent<Renderer>().bounds.size.x;
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
        for (var i = 0; i < GameState.Instance.powerModels.Count; i++)
        {
            GotPower(GameState.Instance.powerModels[i]);
        }
        
    }

    public void GotPower(PowerModel powerModel)
    {
        if(_currentFuel+powerModel.addedFuel<=_maxFuelLimit)
            _currentFuel += powerModel.addedFuel;
        _reFuelRate += powerModel.addedFuelGain;
        _burnFuelRate += powerModel.addedFuelBurnRate;
        _maxSpeed += powerModel.addedSpeed;
        if (_switchSideLeft)
        {
            transform.localScale=new Vector3(transform.localScale.x*powerModel.addedScaleMultiplier, transform.localScale.y*powerModel.addedScaleMultiplier, transform.localScale.z);
          
        }
        else
        {
            transform.localScale=new Vector3(transform.localScale.x*powerModel.addedScaleMultiplier, transform.localScale.y*powerModel.addedScaleMultiplier, transform.localScale.z);
        }
    }
    public float GetCurrentFuelPercent()
    {
        var result = _currentFuel / _maxFuelLimit * 100;
        if (result > 100)
        {
            return 100;
        }
        else if(result<0)
        {
            return 0;
        }
        else
        {
            return Mathf.Round(_currentFuel / _maxFuelLimit*100);
        }
   
    }



    private void Update()
    {
        
        var hitObject = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius,layerMask:groundLayerMask);
        _isGrounded = hitObject != null && _rigidbody2D.velocity.y <= 0;
        _outOfFuel = _currentFuel <= 0 ? true : false;
    
       
        if (Input.GetKeyDown(KeyCode.W))
        {
            _currentSpeed = 0;
        }
        if (Input.GetKey(KeyCode.W)&&!_outOfFuel)
        {
           
            var v = _rigidbody2D.velocity;
            v.y = _currentSpeed;
            if (_isGrounded)
            {
                _currentSpeed = _startSpeed; 
            }
            _currentSpeed += _acceleration * Time.deltaTime;
            _currentSpeed = _currentSpeed >= _maxSpeed ? _maxSpeed : _currentSpeed;
            if (_currentFuel > 0)
            {
                _currentFuel -= _burnFuelRate * Time.deltaTime;
            }
            _rigidbody2D.velocity = v;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left* _horizentalSpeed * Time.deltaTime;
            if (_switchSideLeft)
            {
                transform.localScale=new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);
                _switchSideRight = true;
                _switchSideLeft = false;
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right* _horizentalSpeed * Time.deltaTime;
            if (_switchSideRight)
            {
                transform.localScale=new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);
                _switchSideLeft = true;
                _switchSideRight = false;
            }
        }

        if (transform.position.x >= (_backGroundwidth / 2 - _backgroundHorizentalOffset))
        {
            var vec3 = transform.position;
            vec3.x = vec3.x - _backGroundwidth+_backgroundHorizentalOffset;
            transform.position = vec3;

        }
        if (transform.position.x <= -1*(_backGroundwidth / 2 - _backgroundHorizentalOffset))
        {
            
            var vec3 = transform.position;
            vec3.x = vec3.x + _backGroundwidth-_backgroundHorizentalOffset;
            transform.position = vec3;
        }

        if (_isGrounded)
        {
            if (!_resetSpeed)
            {
                _currentSpeed = 0;
                _resetSpeed = true;
            }
            _Refuel();
        }
        else
        {
            _resetSpeed = false;
        }

      

       
       
        // print("Isgrounded"+_isGrounded);
        // print("Speed"+_currentSpeed);
        // print("Fuel is"+_currentFuel);
     
    }


    private void _Refuel()
    {
        if (_currentFuel <= _maxFuelLimit)
        {
            _currentFuel += _reFuelRate * Time.deltaTime;
            
        }
   
    }
    
  
    
}
