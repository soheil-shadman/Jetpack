using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private float speed = 15.0f;
    public GameObject ControllPlyaer;
    public ParticleSystem PlayerFireParticle;
    public ParticleSystem PlayerStarParticle;
    public ParticleSystem PlayerCloudParticle;
    public ParticleSystem PlayerLandingParticle;
    private bool _isGrounded;
    private bool _showedLanding;
    private bool _wasGrounded;
    private Vector3 oldPosition;
    private bool Falling;
    private bool switchSideRight = false;
    private bool switchSideLeft = true;
    private float FallingThreshold = -0.005f;
    public float currentFuel = 10f;
    public float maxFuel = 20f;
    public float burnRateFuel= 10f;
    public float rifillRateFuel= 10f;
    private Rigidbody2D rb;
    private float goMaxHighSpeed = 40f;
    private float current_speedHight = 0f;
    private float speedHightRate = 15f;
    private float thrustGoHigh = 0.5f;
    private bool takeOff = true;
    


    


    void Start()
    {
    
        Refuel();
        rb = ControllPlyaer.GetComponent<Rigidbody2D>();
        _isGrounded = false;
        _showedLanding = false;
        oldPosition = transform.position;
    }

    void FixedUpdate () {
     
        print("Current Fuel "+currentFuel);
        print("CAnnnnnnnnnn "+_isGrounded);
        
        
        if (Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.D)){
            transform.position += Vector3.right * speed * Time.deltaTime;
            if (switchSideRight)
            {
                transform.localScale=new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);
                switchSideLeft = true;
                switchSideRight = false;
            }

            
        }
        if (Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.A)){
            transform.position += Vector3.left* speed * Time.deltaTime;
            if (switchSideLeft)
            {
                transform.localScale=new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);
                switchSideRight = true;
                switchSideLeft = false;
            }
        }
        if ((Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.W))&&currentFuel>0)
        {
            
            transform.position += Vector3.up* current_speedHight * Time.deltaTime;
            if (takeOff)
            {
                rb.AddForce(transform.up * thrustGoHigh, ForceMode2D.Impulse);
                takeOff = false;
            }
            if (current_speedHight <= goMaxHighSpeed)
            {
                current_speedHight += speedHightRate * Time.deltaTime;
            }
            
            if (!PlayerCloudParticle.isEmitting)
            {
                PlayerCloudParticle.Play();
            }
            if (!PlayerFireParticle.isEmitting)
            {
                PlayerFireParticle.Play();
            }
            if (!PlayerStarParticle.isEmitting)
            {
                PlayerStarParticle.Play();
            }
            currentFuel -= burnRateFuel * Time.deltaTime;
          
        }
        if (Input.GetKey(KeyCode.DownArrow)||Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * speed/4 * Time.deltaTime;
        }
        
        if(rb.velocity.y>=-0.1f)
        {
            PlayerCloudParticle.Stop();
            PlayerFireParticle.Stop();
            PlayerStarParticle.Stop();
        }
        else  {
          
            if (!PlayerCloudParticle.isEmitting)
            {
                PlayerCloudParticle.Play();
            }
            if (!PlayerFireParticle.isEmitting)
            {
                PlayerFireParticle.Play();
            }
            if (!PlayerStarParticle.isEmitting)
            {
                PlayerStarParticle.Play();
            }
            _showedLanding = false;
            _isGrounded = false;
        } 
      //  oldPosition.y = transform.position.y;
        if (_isGrounded&&!_showedLanding)
        {
            PlayerLandingParticle.Play();
            _showedLanding = true;
        }

        if (_isGrounded)
        {
            Refuel();
        }
        
        // float distancePerSecondSinceLastFrame = (transform.position.y - oldPosition.y) * Time.deltaTime;
        // oldPosition.y = transform.position.y;  //set for next frame
        // if (distancePerSecondSinceLastFrame < FallingThreshold)
        // {
        //     Falling = true;
        // }
        // else
        // {
        //     Falling = false;
        // }
        //
        // if (Falling)
        // {
        //     var speeedz  = Vector3.Distance (oldPosition, transform.position) / Time.deltaTime;
        //     if (speeedz > 10f)
        //     {
        //         CMShake.Instance.Shacker(15f,0.1f);
        //     }
        // }
       
      
    }
    void Refuel()
    {
        if (currentFuel <= maxFuel)
        {
            currentFuel += rifillRateFuel * Time.deltaTime;
            
        }
   
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Ground")
        {
          
            PlayerCloudParticle.Stop();
            PlayerFireParticle.Stop();
            PlayerStarParticle.Stop();
            current_speedHight = 0f;
            _showedLanding = false;
            _isGrounded = true;
            takeOff = true;

        }
        
    }

  public  void DIE()
    {
        Destroy(this);
    }

}
