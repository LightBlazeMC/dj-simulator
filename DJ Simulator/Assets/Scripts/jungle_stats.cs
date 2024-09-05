using UnityEngine;
using TMPro;

public class jungle_stats: MonoBehaviour
{
    public SpawnNPC_Jungle scriptA;
    public TMP_Text jungle_stat_text; // The TextMeshPro object to display

  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    int JungleNum = scriptA.JungleNPC;
    jungle_stat_text.SetText("Jungle/DnB: " + JungleNum);
  }
}