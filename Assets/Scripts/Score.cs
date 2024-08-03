using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;
using Unity.VisualScripting;

public class Score : MonoBehaviour
{
    public static Score instance;

    public TextMeshProUGUI currentScore;
    public TextMeshProUGUI hightSocre;

    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentScore.text = score.ToString();
        hightSocre.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        updateHighScore();
    }

    private void updateHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score); // Fixed the typo here
            hightSocre.text = score.ToString();
        }
    }

    public void updateScore()
    {
        score++;
        currentScore.text = score.ToString();
        updateHighScore();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
