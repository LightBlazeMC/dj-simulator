using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int score = 000000;  // Default score value

    public TMP_Text scoreText;  // Reference to the TextMeshPro text component
    public TMP_Text pointsListText;

    public npcManager npcManager;

    bool canAward = true;
    bool canAwardGenre = true;

    // Start is called before the first frame update
    void Start()
    {
        // Reset score when starting a new game
        score = 0;
        scoreText.text = "Score: " + score.ToString();
        pointsListText.text = "Do some cool stuff to get points!";
    }

    // Update is called once per frame
    void Update()
    {
        // Only start the play track coroutine if it's not already running
        if (deck_btn.isPlaying && canAward)
        {
            StartCoroutine(AwardPlayTrackPointsCoroutine());
        }

        // Check for genre match and start coroutine if needed
        if (deck_btn.isPlaying &&
            npcManager.popularGenre == LoadDeck.currentTrackGenre &&
            canAwardGenre &&
            !string.IsNullOrEmpty(LoadDeck.currentTrackGenre) &&
            LoadDeck.currentTrackGenre != "None")
        {
            StartCoroutine(AwardGenrePointsCoroutine());
            Debug.Log("Genre match found! Popular: " + npcManager.popularGenre + ", Playing: " + LoadDeck.currentTrackGenre);
        }
    }

    IEnumerator AwardPlayTrackPointsCoroutine()
    {
        while (deck_btn.isPlaying)
        {
            if (canAward == true)
            {
                canAward = false;
                score = score + 10;
                scoreText.text = "Score: " + score.ToString();
                pointsListText.text = "You played a track!";

                yield return new WaitForSeconds(10f);
                canAward = true;
            }
            else
            {
                yield return null;
            }
        }
    }

    IEnumerator AwardGenrePointsCoroutine()
    {
        while (deck_btn.isPlaying)
        {
            if (canAwardGenre == true)
            {
                canAwardGenre = false;
                score = score + 250;
                scoreText.text = "Score: " + score.ToString();
                pointsListText.text = "You played " + LoadDeck.currentTrackGenre + " music - the crowd loves it!";

                yield return new WaitForSeconds(8f);
                canAwardGenre = true;
            }
            else
            {
                yield return null;
            }
        }
    }

    // Static method to reset score from anywhere
    public static void ResetScore()
    {
        score = 0;
    }
}