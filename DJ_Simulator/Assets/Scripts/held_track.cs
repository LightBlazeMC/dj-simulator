using UnityEngine;
using TMPro;

public class held_track : MonoBehaviour
{
    public string HeldTrack;
    public int TrackID;
    //public SpawnNPC_Jungle scriptA;
    public TMP_Text held_track_text; // The TextMeshPro object to display
    public string genreTag;

  void Start()
  {
    HeldTrack = "None";
    TrackID = 0;
    genreTag = "None";
  }

  // Update is called once per frame
  void Update()
  {
    //int JungleNum = scriptA.JungleNPC;
    held_track_text.SetText("You are currently holding: " + HeldTrack);
    Debug.Log(HeldTrack);
    Debug.Log("Track ID: " + TrackID);
    Debug.Log("Track genre: " + genreTag);
  }
}