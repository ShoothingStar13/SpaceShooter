using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool _isGameOver; 

    public void GameOver()
    {
        _isGameOver = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && _isGameOver)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
