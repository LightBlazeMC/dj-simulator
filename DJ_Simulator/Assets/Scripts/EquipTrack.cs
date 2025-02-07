using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipTrack : MonoBehaviour
{
    [SerializeField] private string TrackName;
    [SerializeField] private int setTrackID;
    [SerializeField] private string SetgenreTag;

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
        held_track.HeldTrack = TrackName;
        held_track.TrackID = setTrackID;
        held_track.genreTag = SetgenreTag;
    }
}
