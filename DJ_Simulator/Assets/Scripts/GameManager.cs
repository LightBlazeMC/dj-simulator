using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float globalBPM; //defines the bpm that is used for sensing calculations (master bpm)
    public float globalBPM_TimeTick;  //stores the result of actual time duration of events based on master bpm

    public static float timer = 300f;
    public bool gameEnded = false;

    public GameObject gameOverScreen; // Reference to the Game Over screen UI

    public TMP_Text timeText;

    public TMP_Text finalScoreText;

    // Start is called before the first frame update
    void Start()
    {
        globalBPM = 128;
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameEnded)
        {
            calcTimeTick();
            UpdateTimer();
        }
    }

    void calcTimeTick()
    {
        globalBPM_TimeTick = (globalBPM / 60);
    }

    void UpdateTimer()
    {
        timer -= Time.deltaTime; // Decrease the timer by the time elapsed since the last frame
        timeText.text = "Time Remaining: " + timer.ToString();
        if (timer <= 0)
        {
            timer = 0;
            EndGame();
        }
    }

    void EndGame()
    {
        gameEnded = true;
        finalScoreText.text = "Score: " + ScoreManager.score.ToString();
        gameOverScreen.SetActive(true); // Show the Game Over screen
        Time.timeScale = 0;
        Debug.Log("Game Over!");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        // Add additional logic here to handle the end of the game, such as stopping gameplay or showing a game over screen
    }
}