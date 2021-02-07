using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText; 
    [SerializeField]
    private Sprite[] _livesSprites;
    [SerializeField]
    private Image _livesImg; 
    [SerializeField]
    private GameObject _gameOverUI; 
    [SerializeField]
    private GameObject _restartText; 
    private GameManager _gameManager; 
    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = ": 0"; 
        _gameOverUI.SetActive(false);
        _restartText.SetActive(false);
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        if(_gameManager == null)
        {
            Debug.LogError("GameManager is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int playerScore)
    {
        _scoreText.text = ": " + playerScore.ToString();
    }

    public void UpdateLives(int currentLives)
    {
        _livesImg.sprite = _livesSprites[currentLives];
        if(currentLives == 0)
        {
            GameOverSequence();
        }
    }

    public void GameOverSequence()
    {
        _gameOverUI.SetActive(true);
        _restartText.SetActive(true);
        //StartCoroutine(GameOverFlickerRoutine());
        _gameManager.GameOver(); 
    }

    //IEnumerator GameOverFlickerRoutine()
    //{
    //    while(true)
    //    {
    //        yield return new WaitForSeconds(.5f);
    //        _gameOverUI.SetActive(false);
    //        yield return new WaitForSeconds(.5f);
    //        _gameOverUI.SetActive(true); 
    //    }
    //}
}
