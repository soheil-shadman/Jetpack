using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance;
    public List<PowerModel> powerModels { get; private set; }
   
    
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            powerModels = new List<PowerModel>();
            
            
        }
        DontDestroyOnLoad(transform.gameObject);
        
    }

    public void ResetGameState()
    {
        powerModels = new List<PowerModel>();
    }
    public void AddPowerTOGameState(PowerModel model)
    {
        powerModels.Add(model);
    }

}
