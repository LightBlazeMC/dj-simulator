using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipTrack : MonoBehaviour
{

    public held_track scriptA;
    public string TrackName;
    public int setTrackID;
    public static string SetgenreTag;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTitle()
    {
        scriptA.HeldTrack = TrackName;
        scriptA.TrackID = setTrackID;
        scriptA.genreTag = SetgenreTag;
    }
}
