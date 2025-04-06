using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcAnimManager : MonoBehaviour
{
    private Animator anim;

    public string npcType;
    private bool isWalking = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isWalking = true;
        StartCoroutine(WalkAfterSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking)
        {
            // Walking animation takes priority
            anim.SetBool("WantsToDance", false);
            anim.SetBool("WantsToIdle", false);
            anim.SetBool("WantsToWalk", true);
        }
        else if ((npcType == held_track.genreTag) && deck_btn.isPlaying)
        {
            anim.SetBool("WantsToDance", true);
            anim.SetBool("WantsToIdle", false);
            anim.SetBool("WantsToWalk", false);
        }
        else
        {
            anim.SetBool("WantsToDance", false);
            anim.SetBool("WantsToIdle", true);
            anim.SetBool("WantsToWalk", false);
        }
    }

    public IEnumerator WalkAfterSpawn()
    {
        // Set walking to true
        isWalking = true;

        // Wait for the specified duration
        yield return new WaitForSeconds(5f);

        // Stop walking after the duration
        isWalking = false;
    }
}
