using UnityEngine;
using TMPro;

public class house_stats: MonoBehaviour
{
    public SpawnNPC_House scriptA;
    public TMP_Text house_stat_text; // The TextMeshPro object to display

  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    int HouseNum = scriptA.HouseNPC;
    house_stat_text.SetText("House: " + HouseNum);
  }
}