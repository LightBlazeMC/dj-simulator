using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcAnimManager : MonoBehaviour
{
    private Animator anim;

    public string npcType;
    private bool isWalking = false;
    private bool isMoving = false;  // New variable to control physical movement
    //[SerializeField] private float walkSpeed = 1.0f; // Movement speed

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        // Show walking animation immediately but don't move yet
        anim.SetBool("WantsToDance", false);
        anim.SetBool("WantsToIdle", false);
        anim.SetBool("WantsToWalk", true);
        isWalking = true;
        isMoving = false;

        // Start the walking sequence
        StartCoroutine(WalkAfterSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        // Animation states are controlled based on walking state and music
        if (isWalking)
        {
            // Walking animation takes priority
            anim.SetBool("WantsToDance", false);
            anim.SetBool("WantsToIdle", false);
            anim.SetBool("WantsToWalk", true);

            // Only move the NPC if isMoving is true
            if (isMoving)
            {
                transform.position += transform.forward * Random.Range(0.5f, 4f) * Time.deltaTime;
            }
        }
        else if ((npcType == held_track.genreTag) && deck_btn.isPlaying)
        {
            // Dancing when preferred genre is playing
            anim.SetBool("WantsToDance", true);
            anim.SetBool("WantsToIdle", false);
            anim.SetBool("WantsToWalk", false);
        }
        else
        {
            // Default to idle
            anim.SetBool("WantsToDance", false);
            anim.SetBool("WantsToIdle", true);
            anim.SetBool("WantsToWalk", false);
        }
    }

    public IEnumerator WalkAfterSpawn()
    {
        // Initial state: walking animation but not moving
        isWalking = true;
        isMoving = false;

        // Wait for a random time before starting to move
        float waitBeforeMovingTime = Random.Range(1f, 13f);
        Debug.Log("NPC will display walking animation for " + waitBeforeMovingTime + " seconds before moving");
        yield return new WaitForSeconds(waitBeforeMovingTime);

        // Start actual movement
        isMoving = true;
        Debug.Log("NPC started moving");

        // Move for a random duration
        float movementDuration = Random.Range(2f, 8f);
        Debug.Log("NPC will move for " + movementDuration + " seconds");
        yield return new WaitForSeconds(movementDuration);

        // Stop moving and walking
        isMoving = false;
        isWalking = false;
        Debug.Log("NPC stopped moving");

        //transform.rotation = Quaternion.Euler(0, 180, 0);
        transform.rotation = Quaternion.Euler(0, Random.Range(150, 180), 0);
        isMoving = true;
        isWalking = true;

        float movementDuration2 = Random.Range(1f, 9f);
        yield return new WaitForSeconds(movementDuration);
        isMoving = false;
        isWalking = false;
        //transform.rotation = Quaternion.Euler(0, Random.Range(100, 200), 0);
    }
}