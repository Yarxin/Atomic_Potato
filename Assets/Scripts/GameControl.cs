using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameControl : MonoBehaviour
{

    public static GameControl instance;

    public GameObject gameOverText;
    public GameObject startGameText;
    public bool gameOver = false;
    public float scrollSpeed = -3f;
    public Text scoreText;
    public Text timeText;
    public float time = 10;
    public float extraTime = 5f;
    public bool started = false;

    private int score = 0;
    private double timeDouble;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == false && started == false && Input.GetMouseButtonDown(0))
        {
            if (started == false && Input.GetMouseButtonDown(0))
            {
                StartGame();
                started = true;
            }
        }

        if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (started == true)
        {
            PotatoTime();
        }
    }

    public void PotatoScored()
    {
        if (gameOver)
        {
            return;
        }
        score++;
        scoreText.text = "Score:" + score.ToString();
    }

    public void PotatoTime()
    {
        if (gameOver)
        {
            return;
        }
        time -= Time.deltaTime;
        timeDouble = System.Convert.ToDouble(time);
        timeDouble = Math.Round(timeDouble, 2);
        timeText.text = "Time: " + timeDouble.ToString();

        if (time <= 0)
        {
            timeText.text = "Time: " + 0;
            PotatoDied();
        }
    }

    public void AddTime()
    {
        time += extraTime;
    }

    public void PotatoDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }

    public void StartGame()
    {
        startGameText.SetActive(false);   
    }
}
