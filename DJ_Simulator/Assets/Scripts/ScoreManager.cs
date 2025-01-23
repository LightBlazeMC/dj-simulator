using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 000000;  // Default score value

    public TMP_Text scoreText;  // Reference to the TextMeshPro text component
    public TMP_Text pointsListText;
    public deck_btn scriptA;

    public held_track held_Track;

    public npcManager npcManager;

    bool canAward = true;
    bool canAwardGenre = true;

    IEnumerator AwardPlayTrackPointsCoroutine()
    {
        while (scriptA.isPlaying)
        {
            if (canAward == true)
            {
                canAward = false;
                score = score + 10;
                //Debug.Log("Points awarded! Total points: " + score);
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
        while (scriptA.isPlaying)
        {
            if (canAwardGenre == true)
            {
                canAwardGenre = false;
                score = score + 250;
                //Debug.Log("Points awarded! Total points: " + score);
                scoreText.text = "Score: " + score.ToString();
                pointsListText.text = "You played a popular genre!";

                yield return new WaitForSeconds(8f);
                canAwardGenre = true;
            }

            else
            {
                yield return null;
            }

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
        pointsListText.text = "Do some cool stuff to get points!";

        StartCoroutine(AwardPlayTrackPointsCoroutine());
        StartCoroutine(AwardGenrePointsCoroutine());
    }
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(AwardPlayTrackPointsCoroutine());

        if (npcManager.popularGenre == "Techno" && held_Track.genreTag == "TECHNO")
        {
            StartCoroutine(AwardGenrePointsCoroutine());
        }

        if (npcManager.popularGenre == "House" && held_Track.genreTag == "HOUSE")
        {
            StartCoroutine(AwardGenrePointsCoroutine());
        }
        if (npcManager.popularGenre == "Jungle" && held_Track.genreTag == "JUNGLE")
        {
            StartCoroutine(AwardGenrePointsCoroutine());
        }
    }
}
