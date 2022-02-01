using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerItem : MonoBehaviour
{
    private PowerModel _model;
    private GameObject _player;

    void Start()
    {
        
        _model = AbyssController.Instance.GivePowers();
        
        
    }

    void OnTriggerEnter2D (Collider2D col)
    {
  
        if (col.gameObject.tag=="Player")
        {
            col.gameObject.GetComponent<PlayerController>().GotPower(_model);
            AbyssController.Instance.SetPowerUpText(_model.description);
            GameState.Instance.AddPowerTOGameState(_model);
            this.gameObject.SetActive(false);
         
        }
    }
    // Update is called once per frame
  
}
