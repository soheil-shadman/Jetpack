using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerPlatform : MonoBehaviour
{
    void OnCollisionEnter2D (Collision2D col){
        if (col.gameObject.tag == "Player") {
            GameState.Instance.ResetGameState();
            CinamaMachineController.Instance.Shacker(15f,0.15f);
            Destroy(col.gameObject);
        }
    }
}
