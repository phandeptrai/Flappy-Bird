using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject gameOverCanvas;
    public GameObject gameStartCanvas;

    public bool game;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        Time.timeScale = 1.0f;
    }

    public void gameAwake()
    {
        gameStartCanvas.SetActive(true);
        Time.timeScale = 0f;
        game = false;
    }
    public void gameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }
    public void startGame()
    {
        Time.timeScale = 1f;
        game = true;
        gameStartCanvas.SetActive(false);
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
