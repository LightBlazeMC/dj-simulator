using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcAnimManager : MonoBehaviour
{
    private Animator anim;

    public string npcType;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (npcType == npcManager.popularGenre)
        {
            anim.SetBool("WantsToDance", true);
            anim.SetBool("WantsToIdle", false);
        }
        else
        {
            anim.SetBool("WantsToDance", false);
            anim.SetBool("WantsToIdle", true);
        }
    }
}
