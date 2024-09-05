using UnityEngine;
using TMPro;

public class techno_stats: MonoBehaviour
{
    public SpawnNPC_Techno scriptA;
    public TMP_Text techno_stat_text; // The TextMeshPro object to display

  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    int TechnoNum = scriptA.TechnoNPC;
    techno_stat_text.SetText("Techno: " + TechnoNum);
  }
}