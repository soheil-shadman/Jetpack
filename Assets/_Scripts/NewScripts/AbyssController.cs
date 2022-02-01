using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AbyssController : MonoBehaviour
{  
    [Header("Player Object")]
    [SerializeField] private GameObject _player;   
    
    [Header("Game Texts")]
    [SerializeField] private TMPro.TextMeshProUGUI _scoreText;
    [SerializeField] private TMPro.TextMeshProUGUI _fuelText;
    [SerializeField] private TMPro.TextMeshProUGUI _itemStatusText;
    
    [Header("Game Status Texts")]
    [SerializeField] private TMPro.TextMeshProUGUI _dieText;
    [SerializeField] private TMPro.TextMeshProUGUI _victoryText;
  
    
    
    public static AbyssController Instance;
    private List<PowerModel> _powerModels;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _powerModels =new List<PowerModel>();
            _powerModels.Add(
                new PowerModel(0f,0f,0f,0f,1f,"This item Do nothing !!!! rofl"));
            _powerModels.Add(
                new PowerModel(30f,0f,0f,0f,1f,"Get more Fuel Man ...."));
            _powerModels.Add(
                new PowerModel(0f,0f,0f,0f,1.2f,"Big man has a Big nose ..."));
            _powerModels.Add(
                new PowerModel(0f,10f,0f,0f,1f,"Faster ... but still a Loser"));
            _powerModels.Add(
                new PowerModel(0f,0f,0f,5f,1f,"Guess something is leaking? ow"));
            _powerModels.Add(
                new PowerModel(400f,0f,0f,0f,1f,"UR MOM SO FAT and thicc ... which means more fuel"));
            _powerModels.Add(
                new PowerModel(-100f,-10f,0f,0f,2f,"BEHZAD'S GAZE IS UPON YOU"));
            
        }
    }

    // Temp Data
    private float _score;
    public float _victoryScore=100f;
    private Vector3 oldPostion;

    void Start()
    {
        _score = 0;

    }
    public PowerModel GivePowers()
    {
        int index = Random.Range(0, _powerModels.Count);
        return _powerModels[index];
    }

    public void SetPowerUpText(string data)
    {
        _itemStatusText.GetComponent<TMP_Text>().text = data;
        _itemStatusText.gameObject.SetActive(true);
        StartCoroutine(_PowerUpTextDispose());

    }
 
    private IEnumerator _LoadNextSceneCoroutinge()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private IEnumerator _PowerUpTextDispose()
    {
        yield return new WaitForSeconds(3f);
        _itemStatusText.GetComponent<TMP_Text>().text = "";
        _itemStatusText.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene();
            // GameState.Instance.ResetGameState();
            GameState.Instance.ResetGameState();
            SceneManager.LoadScene(0);
        }
        if (Input.GetKey(KeyCode.T))
        {
            Scene scene = SceneManager.GetActiveScene();
            // GameState.Instance.ResetGameState();
            SceneManager.LoadScene(scene.name);
        }
        if (_player.gameObject != null)
        {
            if (_player.transform.position.y > oldPostion.y)
            {
                _score = _player.transform.position.y;
                oldPostion = _player.transform.position;
                _score = (int) _score;
                _scoreText.text = _score.ToString();
            }
            
            
           
        }

        if (_player.gameObject != null)
        {
            _fuelText.GetComponent<TMP_Text>().text =
                _player.GetComponent<PlayerController>().GetCurrentFuelPercent().ToString() + "%";
        }

        if (_score >= _victoryScore)
        {
            _fuelText.GetComponent<TMP_Text>().text = "---";
            _victoryText.gameObject.SetActive(true);
           StartCoroutine(_LoadNextSceneCoroutinge()) ;
            Destroy(_player);
        }

        if (_player.gameObject == null&&_score<_victoryScore)
        {
            _fuelText.GetComponent<TMP_Text>().text = "---";
            _dieText.gameObject.SetActive(true);
        }

        
    }
}
