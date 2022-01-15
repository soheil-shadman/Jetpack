using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject Player;
    public TMPro.TextMeshProUGUI textMeshPro;
    public TMPro.TextMeshProUGUI DiedText;
    public TMPro.TextMeshProUGUI VictoryText;

    private float score;
    public float victoryScore=200f;
    private Vector3 oldPostion;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        oldPostion = Player.gameObject.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        if (Player.gameObject != null)
        {
            if (Player.transform.position.y > oldPostion.y)
            {
                score = Player.transform.position.y;
                oldPostion = Player.transform.position;
                score = (int) score;
                textMeshPro.text = score.ToString();
            }
            
           
        }

        if (score >= victoryScore)
        {
            VictoryText.gameObject.SetActive(true);
            Destroy(Player);
        }

        if (Player.gameObject == null&&score<victoryScore)
        {
            DiedText.gameObject.SetActive(true);
        }

        
    }
}
